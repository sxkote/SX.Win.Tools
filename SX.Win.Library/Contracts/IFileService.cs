using SX.Win.Library.Models;

namespace SX.Win.Library.Contracts
{
    public interface IFileService
    {
        Task<List<DirectoryInfo>> GetFoldersAsync(DirectoryInfo directory, string filter, CancellationToken ct);
        Task<List<DirectoryInfo>> GetFoldersAsync(string path, string filter, CancellationToken ct);
        Task<List<FileInfo>> GetFilesAsync(DirectoryInfo directory, string filter, CancellationToken ct);
        Task<List<FileInfo>> GetFilesAsync(string path, string filter, CancellationToken ct);
        Task<List<FileInfo>> GetAllFilesAsync(DirectoryInfo directory, string filter, ProgressOptions options, CancellationToken ct);
        Task<List<FileInfo>> GetAllFilesAsync(string path, string filter, ProgressOptions options, CancellationToken ct);


        bool MatchFiles(FileModel file, FileModel match, FileMatchingOptions options);
        List<FileModel> FindFiles(List<FileModel> allFiles, FileModel search, FileMatchingOptions options, CancellationToken ct);

        byte[] ReadFile(FileModel file);
        byte[] ReadFile(string path);


        string CalculateMD5(byte[] data);

        FileMD5 CalculateFileMD5(FileModel file, int countOfBytesToCalculateHash = 0);
        FileMD5 CalculateFileMD5(string path, int countOfBytesToCalculateHash = 0);
        Task<FileMD5> CalculateFileMD5Async(string path, int countOfBytesToCalculateHash = 0);


        void CopyFile(FileModel file, string location);
        void MoveFile(FileModel file, string location);
    }
}
