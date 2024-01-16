using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKBlog.Models
{
    public class EncryptionHelper : IEncryptionHelper
    {
        public (string encryptedResult, byte[] key, byte[] IV) Encrypt(string data)
        {
            //Use tuple to return the cryptographic parameters that makes the system 
            //very secure Only God and the PC at the moment of execution knows this values
            //Save the parameters to db so as to use it in decryption.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.GenerateKey();
                aesAlg.GenerateIV();
                // Access the generated key and IV
                byte[] key = aesAlg.Key;
                byte[] iv = aesAlg.IV;


                //aesAlg.Key = Encoding.UTF8.GetBytes(key);
                //aesAlg.IV = Encoding.UTF8.GetBytes(IV);
                //aesAlg.IV = new byte[16]; // Initialization Vector, can be random for each encryption

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(data);
                        }
                    }

                    return (Convert.ToBase64String(msEncrypt.ToArray()), key, iv);
                }
            }
        }

        public string Decrypt(string encryptedData, byte[] key, byte[] IV)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = IV;

                //aesAlg.Key = Encoding.UTF8.GetBytes(key);//use when key and IV are strings
                //aesAlg.IV = Encoding.UTF8.GetBytes(IV);
                //aesAlg.IV = new byte[16]; // Initialization Vector, should match the IV used during encryption

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(encryptedData)))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
