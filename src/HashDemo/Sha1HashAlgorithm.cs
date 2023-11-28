using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HashDemo
{
    public class Sha1HashAlgorithm : HashAlgorithmBase
    {
        protected override HashAlgorithm GetHashAlgorithm()
        {
            return new SHA1Managed();
        }
    }
}
