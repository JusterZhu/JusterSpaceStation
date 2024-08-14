using System.Security.Cryptography;
using System.Text;

namespace HashDemo
{
    public abstract class HashAlgorithmBase
    {
        public string ComputeHash(string input)
        {
            byte[] data = GetHashAlgorithm().ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        protected abstract HashAlgorithm GetHashAlgorithm();
    }

}
