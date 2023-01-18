namespace SX.Win.Library.Contracts
{
    public interface IPictureService
    {
        DateTime? GetDate(string filename);

        bool IsJPEG(string path);
        bool IsJPEG(FileInfo image);


        bool IsImage(string path);
        bool IsImage(FileInfo image);
    }
}
