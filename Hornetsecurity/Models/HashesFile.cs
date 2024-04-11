


using System.ComponentModel.DataAnnotations;

namespace Hornetsecurity.Models
{
    public class HashesFile
    {
        [Key]
        public string Path { get; set; }
        public string Name { get; set; }
        public string Md5 { get; set; }
        public string Sha1 { get; set; }
        public string Sha256 { get; set; }
        public long FileSize { get; set; }

        public int Scanned { get; set; }
        public DateTime? LastSeen { get; set; }


        public override bool Equals(object obj)
        {
            return obj is HashesFile hashFile && Path == hashFile.Path;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Path);
        }

    }
}
