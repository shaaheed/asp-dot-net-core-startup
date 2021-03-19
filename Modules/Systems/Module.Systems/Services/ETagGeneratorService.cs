using Newtonsoft.Json;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Module.Systems.Services
{
    public class ETagGeneratorService : IETagGeneratorService
    {

        public string GetETag(object data)
        {
            var content = JsonConvert.SerializeObject(data);
            var bytes = Encoding.UTF8.GetBytes(content);
            return GetETag(bytes);
        }

        public string GetETag(string key, byte[] contentBytes)
        {
            var keyBytes = Encoding.UTF8.GetBytes(key);
            var combinedBytes = Combine(keyBytes, contentBytes);
            return GenerateETag(combinedBytes);
        }

        public string GetETag(byte[] contentBytes)
        {
            return GenerateETag(contentBytes);
        }

        private string GenerateETag(byte[] data)
        {
            using (var md5 = MD5.Create())
            {
                var hash = md5.ComputeHash(data);
                string hex = BitConverter.ToString(hash);
                return hex.Replace("-", "");
            }
        }

        private byte[] Combine(byte[] a, byte[] b)
        {
            byte[] c = new byte[a.Length + b.Length];
            Buffer.BlockCopy(a, 0, c, 0, a.Length);
            Buffer.BlockCopy(b, 0, c, a.Length, b.Length);
            return c;
        }
    }
}
