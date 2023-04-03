using System.Security.Cryptography;
using System.Text;

namespace Todo.ApplicationLayer.Services.Hashing
{
    public class MD5Hasher : IHasher
    {
        public string HashString(string data)
        {
            byte[] dataBytes = Encoding.Default.GetBytes(data);
            return Encoding.Default.GetString(MD5.HashData(dataBytes));
        }
    }
}