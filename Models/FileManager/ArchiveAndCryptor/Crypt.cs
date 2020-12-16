using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Security.Cryptography;

namespace Scramblers
{
    class CryptoManager
    {
        Rijndael myRijndael;

        public CryptoManager()
        {
            myRijndael = Rijndael.Create();
            myRijndael.Padding = PaddingMode.None;
        }

        public void EncryptFile(string pathFile, string pathEncrypt)
        {
            if (!File.Exists(pathEncrypt))
            {
                File.Copy(pathFile, pathEncrypt);
                File.Encrypt(pathEncrypt);
            }
        }

        public void DecryptFile(string pathFile, string pathDecrypt)
        {
            if (!File.Exists(pathDecrypt))
            {
                File.Copy(pathFile, pathDecrypt);
                File.Decrypt(pathDecrypt);
            }
        }

    }
}
