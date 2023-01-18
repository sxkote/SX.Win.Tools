using System.Text;

namespace SX.Shared.Models
{
    public class FileData
    {
        public FileName FileName { get; private set; }

        public byte[]? Data { get; private set; }

        public string GetHashMD5() => this.Data == null ? "" : CalculateMD5(this.Data);

        public int GetSize() => this.Data == null ? 0 : this.Data.Length;

        public FileData(FileName filename, byte[]? data = null)
        {
            this.FileName = filename;
            this.Data = data;
        }

        static public string CalculateMD5(byte[] data)
        {
            byte[] hash;

            using (var md5 = System.Security.Cryptography.MD5.Create())
                hash = md5.ComputeHash(data);

            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
                sBuilder.Append(hash[i].ToString("x2"));

            return sBuilder.ToString();
        }

        static public implicit operator byte[]?(FileData data) => data?.Data;

        public override string ToString() => this.FileName?.Name ?? "";
    }
}
