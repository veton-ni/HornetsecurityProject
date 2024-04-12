

using Hornetsecurity.Models;
using System.Security.Cryptography;
using System.Text;

namespace Hornetsecurity.Utils
{
    internal class FileUtils
    {

        public static bool IsFolderPathValid(string path)
        {
            return Directory.Exists(path);
        }

        public static bool CreateFile(string path)
        {
            if(File.Exists(path)) return true;

            File.Create(path);
            

            return true;
        }


        public static HashesFile ScanFile(string path)
        {

            FileInfo fileInfo = new FileInfo(path);

            HashesFile details = new()
            {
                Name = fileInfo.Name,
                Path = path,
                FileSize = fileInfo.Length,
                Md5 = CalculateM5(path),
                Sha1 = CalculateSHA1(path),
                Sha256 = CalculateSHA256(path),
                Scanned = 0,
                LastSeen = DateTime.Now
            };

            return details;
        }


        private static string CalculateM5(string path)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(path))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }
        private static string CalculateSHA1(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open))
            using (BufferedStream bs = new BufferedStream(fs))
            {
                using (SHA1Managed sha1 = new SHA1Managed())
                {
                    byte[] hash = sha1.ComputeHash(bs);
                    StringBuilder formatted = new StringBuilder(2 * hash.Length);
                    foreach (byte b in hash)
                    {
                        formatted.AppendFormat("{0:X2}", b);
                    }
                    return formatted.ToString();
                }
            }
        }
        private static string CalculateSHA256(string path)
        {
            using (FileStream stream = File.OpenRead(path))
            {
                var sha = new SHA256Managed();
                byte[] checksum = sha.ComputeHash(stream);
                return BitConverter.ToString(checksum).Replace("-", string.Empty);
            }
        }


    }
}
