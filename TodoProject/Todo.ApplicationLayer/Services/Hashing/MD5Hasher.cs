using System.Security.Cryptography;
using System.Text;

namespace Todo.ApplicationLayer.Services.Hashing
{
    public class MD5Hasher : IHasher
    {
        public string HashString(string data)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            byte[] dataBytes = Encoding.GetEncoding("windows-1251").GetBytes(data);
            byte[] hashedBytes = MD5.HashData(dataBytes);
            return Convert.ToHexString(hashedBytes);
        }
    }
}