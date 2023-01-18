using ExifLib;
using SX.Win.Library.Contracts;

namespace SX.Win.Library.Services
{
    public class PictureService : IPictureService
    {
        public DateTime? GetDate(string filename)
        {
            try
            {
                using (ExifReader reader = new ExifReader(filename))
                {
                    return this.ReadDate(reader);
                }
            }
            catch { return null; }
        }

        private DateTime? ReadDate(ExifReader reader)
        {
            if (reader == null)
                return null;

            // Extract the tag data using the ExifTags enumeration
            if (reader.GetTagValue<DateTime>(ExifTags.DateTimeDigitized, out DateTime datePictureTaken))
                return datePictureTaken;

            return null;
        }

        public bool IsJPEG(string path) => IsJPEG(new FileInfo(path));
        public bool IsJPEG(FileInfo image)
        {
            if (image == null)
                return false;

            var extension = image.Extension.ToLower();

            return extension.Equals(".jpg")
                || extension.Equals(".jpeg");
        }

        public bool IsImage(string path) => IsImage(new FileInfo(path));
        public bool IsImage(FileInfo image)
        {
            if (image == null)
                return false;

            var extension = image.Extension.ToLower();

            return extension.Equals(".jpg")
                || extension.Equals(".jpeg")
                || extension.Equals(".png");
        }
    }
}
