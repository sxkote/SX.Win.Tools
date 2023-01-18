namespace SX.Win.Library.Models
{
    public class FileMD5
    {
        public int Count { get; set; }
        public string Hash { get; set; }

        public FileMD5(string hash, int count = 0)
        {
            this.Hash = hash;
            this.Count = count;
        }

        public bool IsEmpty() => String.IsNullOrEmpty(this.Hash);

        public override bool Equals(object obj)
        {
            var target = obj as FileMD5;
            if (target == null) return false;

            return target.Count == this.Count && target.Hash.Equals(this.Hash, StringComparison.OrdinalIgnoreCase);
        }

        public override string ToString()
        {
            return this.Hash;
        }

        static public FileMD5 EMPTY { get { return new FileMD5("", 0); } }
    }
}
