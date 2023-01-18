using SX.Win.Library.Contracts;
using SX.Win.Library.Models;

namespace SX.Win.Library.Services
{
    public class FileSearchingService : ProgressService, IProgressService, ISearchingService
    {

        protected DirectoryInfo _lastLocation = null;
        protected List<FileModel> _lastFiles = null;
        protected List<DirectoryInfo> _lastLocations = null;

        private readonly IFileService _fileService;

        public FileSearchingService(IFileService fileService)
        {
            _fileService = fileService;
        }

        protected async Task<List<FileModel>> ReadLocationFiles(string location, string filter, ProgressOptions options, CancellationToken ct, bool reloadLocation = false)
        {
            var currentLocation = new DirectoryInfo(location);

            // check if last location === current location
            if (!reloadLocation && _lastLocation != null && _lastFiles != null && _lastFiles.Count > 0 && _lastLocation.FullName.Equals(currentLocation.FullName, StringComparison.OrdinalIgnoreCase))
                return _lastFiles;

            // save last location
            _lastLocation = currentLocation;

            // read all files from the location
            _lastFiles = (await _fileService.GetAllFilesAsync(location, filter, options, ct))
                .Select(f => (FileModel)f)
                .ToList();

            return _lastFiles;
        }

        public async Task<List<FileModel>> SearchAsync(FilesSearchingOptions options, CancellationToken ct)
        {
            // all files from the path
            var allFiles = await this.ReadLocationFiles(options.Location, "", options, ct);

            this.AddLog($"Building result for {options.FileNames.Length} files ...", options.ProgressLog);
            // строим результат поиска - список искомых файлов в результат
            var result = options.FileNames
                .Select(filename => (FileModel)new FileInfo(filename))
                .ToList();

            for (int i = 0; i < result.Count; i++)
            {
                // останавливаемся, если нужно
                ct.ThrowIfCancellationRequested();

                // current file to search
                var search = result[i];

                await Task.Run(() =>
                {
                    this.AddLog("", options.ProgressLog);
                    this.AddLog($"Searching for: {search.Name} [{search.Size} bytes] ({i + 1}/{result.Count}) ...", options.ProgressLog);

                    this.ChangeStatus(i, result.Count, $"Searching for: {search.Name} ({i + 1}/{result.Count}) through {allFiles.Count} files", options.ProgressStatus);

                    // finding same files
                    var similar = _fileService.FindFiles(allFiles, search, options.FileMatching, ct);

                    // if any files found
                    if (similar != null && similar.Any())
                    {
                        search.Links = similar;
                        foreach (var f in similar)
                            this.AddLog($"Found: {f.FullName} [{f.Size} bytes]", options.ProgressLog);
                    }
                }, ct);
            }

            await Task.Run(() =>
            {
                // process not found files
                var notFoundFiles = result.Where(f => !f.HasLinks).ToList();
                if (!String.IsNullOrWhiteSpace(options.CopyNotFoundLocation) && notFoundFiles != null && notFoundFiles.Any())
                {
                    this.AddLog($"Making Copy: {notFoundFiles.Count} not found files...", options.ProgressLog);

                    for (var i = 0; i < notFoundFiles.Count; i++)
                    {
                        ct.ThrowIfCancellationRequested();

                        this.ChangeStatus(i, notFoundFiles.Count, $"Copying: ({i + 1}/{notFoundFiles.Count}) {notFoundFiles[i].Name} to {options.CopyNotFoundLocation}", options.ProgressStatus);

                        _fileService.CopyFile(notFoundFiles[i], options.CopyNotFoundLocation);
                    }
                }
            }, ct);

            await Task.Run(() =>
            {
                // process found files
                var foundFiles = result.Where(f => f.HasLinks).ToList();
                if (!String.IsNullOrWhiteSpace(options.MoveFoundLocation) && foundFiles != null && foundFiles.Any())
                {
                    this.AddLog($"Moving: {foundFiles.Count} found files to {options.MoveFoundLocation}...", options.ProgressLog);

                    for (var i = 0; i < foundFiles.Count; i++)
                    {
                        ct.ThrowIfCancellationRequested();

                        this.ChangeStatus(i, foundFiles.Count, $"Copying: ({i + 1}/{foundFiles.Count}) {foundFiles[i].Name} to {options.MoveFoundLocation}", options.ProgressStatus);

                        _fileService.MoveFile(foundFiles[i], options.MoveFoundLocation);
                    }
                }
            }, ct);

            this.ChangeStatus(0, 0, "done", options.ProgressStatus);

            return result;
        }

        private bool IsSelectedFolder(string path, string[] selectedFolders)
        {
            if (selectedFolders == null || selectedFolders.Length <= 0)
                return false;

            var p = path.ToLower();

            return selectedFolders.Any(f => p.Contains(f.ToLower()));
            //return p.Contains("\\_selected")
            //    || p.Contains("\\_sel");
            //    //|| p.Contains("\\notebook's photos\\");
        }

        public async Task<FilesAnalysResults> AnalysAsync(FilesAnalysOptions options, CancellationToken ct)
        {
            var result = new FilesAnalysResults();

            // all files from the path
            var allFiles = await this.ReadLocationFiles(options.Location, "", options, ct, true);

            //var extensions = options.GetStandardExtensions();

            // large files
            result.LargeFiles = allFiles
                .Where(f => f.Size > options.LargeSize)
                .ToList();

            // all extensions
            result.ExtensionsAll = allFiles
                .GroupBy(f => f.Extension.ToLower())
                .Select(gr => new FilesAnalysResultExtensionInfo(gr.Key, gr))
                .ToList();

            // undefined extensions
            result.ExtensionsUnknown = result.ExtensionsAll
                .Where(item => !options.StandardExtensions.Any(e => item.Extension.Equals(e, StringComparison.OrdinalIgnoreCase)))
                .ToList();

            // duplicate files
            var duplicates = new List<FileModel>();
            for (int i = 0; i < allFiles.Count; i++)
            {
                ct.ThrowIfCancellationRequested();

                // current file
                var search = allFiles[i];

                // avoiding selected foto
                if (this.IsSelectedFolder(search.FullName, options.DuplicateSelectedFolders))
                    continue;

                // if the file already is a duplicate - skip it
                if (duplicates.Any(f => f == search))
                    continue;

                await Task.Run(() =>
                {
                    this.ChangeStatus(i, allFiles.Count, $"Comparing: {search.FullName} ({i}/{allFiles.Count})... ", options.ProgressStatus);

                    // get similar files
                    var similar = _fileService
                        .FindFiles(allFiles, search, options.FileMatching, ct);

                    // avoiding selected fotos
                    if (options.DuplicateSelectedFolders != null)
                        similar = similar.Where(f => !this.IsSelectedFolder(f.FullName, options.DuplicateSelectedFolders)).ToList();

                    // no similar size - no links
                    if (similar == null || !similar.Any())
                        return;

                    // set links to search file
                    search.Links = similar;
                    // add duplicates to list (to skip next time)
                    duplicates.AddRange(similar);
                    // add file+duplicates to result
                    result.Duplicates.Add(search);

                    this.AddLog($"", options.ProgressLog);
                    this.AddLog($"Original : {search.FullName} [{search.Size}]", options.ProgressLog);
                    foreach (var link in search.Links)
                        this.AddLog($"Duplicate: {link.FullName} [{link.Size}]", options.ProgressLog);
                }, ct);
            }

            this.ChangeStatus(0, 0, "done", options.ProgressStatus);

            return result;
        }
    }
}
