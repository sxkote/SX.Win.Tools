using SX.Win.Library.Contracts;
using SX.Win.Library.Models;
using System.Security.Cryptography;
using System.Text;

namespace SX.Win.Library.Services
{
    public class FileService : ProgressService, IProgressService, IFileService
    {
        public async Task<List<DirectoryInfo>> GetFoldersAsync(DirectoryInfo directory, string filter, CancellationToken ct)
        {
            return await Task.Run(() =>
            {
                // get all subfolders
                var result = directory.GetDirectories(filter, SearchOption.AllDirectories).ToList();
                // add the root folder
                result.Insert(0, directory);

                return result;
            }, ct);
        }
        public async Task<List<DirectoryInfo>> GetFoldersAsync(string path, string filter, CancellationToken ct) => await this.GetFoldersAsync(new DirectoryInfo(path), filter, ct);


        public async Task<List<FileInfo>> GetFilesAsync(DirectoryInfo directory, string filter, CancellationToken ct)
        {
            return await Task.Run(() =>
            {
                return directory
                    .GetFiles(filter, SearchOption.TopDirectoryOnly)
                    .ToList();
            }, ct);
        }
        public async Task<List<FileInfo>> GetFilesAsync(string path, string filter, CancellationToken ct) => await this.GetFilesAsync(new DirectoryInfo(path), filter, ct);

        public async Task<List<FileInfo>> GetAllFilesAsync(DirectoryInfo directory, string filter, ProgressOptions options, CancellationToken ct)
        {
            this.AddLog($"Reading location: {directory.FullName}", options.ProgressLog);

            var locations = await this.GetFoldersAsync(directory, "", ct);

            this.AddLog($"Total {locations.Count} locations found", options.ProgressLog);

            var result = new List<FileInfo>();
            for (int i = 0; i < locations.Count; i++)
            {
                ct.ThrowIfCancellationRequested();

                this.ChangeStatus(i, locations.Count, $"Reading location: {locations[i].FullName} ({i + 1}/{locations.Count})", options.ProgressStatus);

                var files = await this.GetFilesAsync(locations[i], filter, ct);
                if (files != null && files.Any())
                    result.AddRange(files);
            }

            this.ChangeStatus(0, 0, $"Reading completed for {directory.FullName}", options.ProgressStatus);

            this.AddLog($"Total {result.Count} files found", options.ProgressLog);

            return result;
        }
        public async Task<List<FileInfo>> GetAllFilesAsync(string path, string filter, ProgressOptions options, CancellationToken ct) => await this.GetAllFilesAsync(new DirectoryInfo(path), filter, options, ct);


        private void SetFileMD5(ref FileModel file, int countOfBytesToCalculateHash = 0)
        {
            if (file == null || !file.MD5.IsEmpty() && file.MD5.Count == countOfBytesToCalculateHash)
                return;

            file.MD5 = this.CalculateFileMD5(file, countOfBytesToCalculateHash);
        }

        public bool MatchFiles(FileModel file, FileModel match, FileMatchingOptions options)
        {
            if (file == null || match == null)
                return false;

            if (options.MatchFileName && !file.Name.Equals(match.Name, StringComparison.OrdinalIgnoreCase))
                return false;

            if (options.MatchFileSize && file.Size != match.Size)
                return false;

            if (options.ExcludeSameFilePath && file.FullName.Equals(match.FullName, StringComparison.OrdinalIgnoreCase))
                return false;

            if (options.MatchFileMD5)
            {
                this.SetFileMD5(ref file, options.CountOfBytesToCalculateHash);
                this.SetFileMD5(ref match, options.CountOfBytesToCalculateHash);

                if (!file.MD5.Equals(match.MD5))
                    return false;
            }

            return true;
        }

        public List<FileModel> FindFiles(List<FileModel> allFiles, FileModel search, FileMatchingOptions options, CancellationToken ct)
        {
            var query = allFiles.AsQueryable();

            // filter by size
            if (options.MatchFileSize)
                query = query.Where(f => f.Size == search.Size);

            // filter by name
            if (options.MatchFileName)
                query = query.Where(f => f.Name.Equals(search.Name, StringComparison.OrdinalIgnoreCase));

            // exlude same file
            if (options.ExcludeSameFilePath)
                query = query.Where(f => !f.FullName.Equals(search.FullName, StringComparison.OrdinalIgnoreCase));

            // final match
            return query.ToList()
                .Where(f => this.MatchFiles(search, f, options))
                .ToList();
        }


        public byte[] ReadFile(FileModel file) => File.ReadAllBytes(file.FullName);
        public byte[] ReadFile(string path) => File.ReadAllBytes(path);

        public string CalculateMD5(byte[] data)
        {
            if (data == null || data.Length <= 0)
                return "";

            using (var md5Hash = MD5.Create())
                return CalculateHash(md5Hash, data);
        }

        public FileMD5 CalculateFileMD5(FileModel file, int countOfBytesToCalculateHash = 0)
        {
            if (file == null)
                return FileMD5.EMPTY;

            // check if file is NOT larger than total size 
            if (file.Size <= countOfBytesToCalculateHash || countOfBytesToCalculateHash == 0)
                return new FileMD5(this.CalculateMD5(this.ReadFile(file)), countOfBytesToCalculateHash);

            byte[] array = new byte[countOfBytesToCalculateHash];

            try
            {
                if (file.IsImage())
                {
                    using (var reader = new BinaryReader(new FileStream(file.FullName, FileMode.Open)))
                    {
                        reader.BaseStream.Seek(-countOfBytesToCalculateHash, SeekOrigin.End);
                        reader.Read(array, 0, countOfBytesToCalculateHash);
                    }
                }
                else
                {
                    // half size of the amount of bytes
                    int halfBufferSize = countOfBytesToCalculateHash / 2;

                    // total size of reading bytes
                    int restBufferSize = countOfBytesToCalculateHash - halfBufferSize;

                    using (var reader = new BinaryReader(new FileStream(file.FullName, FileMode.Open)))
                    {
                        reader.Read(array, 0, halfBufferSize);
                        reader.BaseStream.Seek(-restBufferSize, SeekOrigin.End);
                        reader.Read(array, halfBufferSize, restBufferSize);
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                return FileMD5.EMPTY;
            }

            return new FileMD5(this.CalculateMD5(array), countOfBytesToCalculateHash);
        }
        public FileMD5 CalculateFileMD5(string path, int countOfBytesToCalculateHash = 0) => CalculateFileMD5(new FileInfo(path), countOfBytesToCalculateHash);
        public async Task<FileMD5> CalculateFileMD5Async(string path, int countOfBytesToCalculateHash = 0) => await Task.Run(() => CalculateFileMD5(path, countOfBytesToCalculateHash));



        public void CopyFile(FileModel file, string location)
        {
            var targetFileName = location + $"\\{file.Name}";

            int index = 1;
            while (File.Exists(targetFileName))
                targetFileName = location + $"\\{Path.GetFileNameWithoutExtension(file.Name)}_{index++}{file.Extension}";

            File.Copy(file.FullName, targetFileName, false);
        }
        public void MoveFile(FileModel file, string location)
        {
            File.Move(file.FullName, location + $"\\{file.Name}", false);
        }

        static public string CalculateHash(HashAlgorithm algorithm, byte[] data)
        {
            byte[] hash = algorithm.ComputeHash(data);

            var sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
                sb.Append(hash[i].ToString("x2"));

            return sb.ToString();
        }

    }
}
