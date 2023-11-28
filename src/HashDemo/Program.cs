namespace HashDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string textToHash = "Hello, World!";
            HashAlgorithmBase md5 = new Md5HashAlgorithm();
            string md5Hash = md5.ComputeHash(textToHash);
            Console.WriteLine(md5Hash);

            HashAlgorithmBase sha1 = new Sha1HashAlgorithm();
            string sha1Hash = sha1.ComputeHash(textToHash);
            Console.WriteLine(sha1Hash);

            HashAlgorithmBase sha256 = new Sha256HashAlgorithm();
            string sha256Hash = sha256.ComputeHash(textToHash);
            Console.WriteLine(sha256Hash);
        }
    }
}
