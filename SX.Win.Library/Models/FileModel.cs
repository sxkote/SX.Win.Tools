namespace SX.Win.Library.Models
{
    public class FileModel
    {
        public Guid ID { get; set; }
        public string FullName { get; set; }
        public string Name { get; set; }
        public long Size { get; set; }
        public string Extension { get; set; }
        public FileMD5 MD5 { get; set; } = FileMD5.EMPTY;

        public List<FileModel> Links { get; set; } = new List<FileModel>();

        public bool HasLinks => this.Links.Any();

        public bool IsImage()
        {
            var ext = this.Extension.ToLower();
            return ext == ".jpg" || ext == ".jpeg" || ext == ".png" || ext == ".bmp";
        }

        static public implicit operator FileModel(FileInfo file)
        {
            return new FileModel()
            {
                ID = Guid.NewGuid(),
                Name = file.Name,
                FullName = file.FullName,
                Extension = file.Extension,
                Size = file.Length
            };
        }

        public void Link(FileModel file)
        {
            if (file == null)
                return;

            if (this.Links.Any(l => l.ID == file.ID))
                return;

            this.Links.Add(file);
        }
    }
}
