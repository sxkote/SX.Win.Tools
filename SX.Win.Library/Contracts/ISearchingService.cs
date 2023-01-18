using SX.Win.Library.Models;

namespace SX.Win.Library.Contracts
{
    public interface ISearchingService
    {
        Task<List<FileModel>> SearchAsync(FilesSearchingOptions options, CancellationToken ct);

        Task<FilesAnalysResults> AnalysAsync(FilesAnalysOptions options, CancellationToken ct);
    }
}
