using System.Security.Cryptography;

namespace AccioBook.CrossCutting.Criptografy
{
    public static class StringCryptografyExtensions
    {
        private const string KEY = "CJBdBvsQ2MFN7qhxuOSwtlHWoMDTU3QF7RTgy9g8rEM=";
        private const string IV = "4kCoksOcwyNk1ueLFUPgaQ==";

        public static string Encrypt(this string clearValue)
        {
            byte[] encrypted;

            using (var aes = Aes.Create())
            {
                //var t = Convert.ToBase64String(aes.Key);
                //var t2 = Convert.ToBase64String(aes.IV);


                aes.Key = Convert.FromBase64String(KEY);
                aes.IV = Convert.FromBase64String(IV);

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                // Create the streams used for encryption.
                using (var msEncrypt = new MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(clearValue);
                        }

                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(encrypted);
        }

        public static string Decrypt(this string encryptedValue)
        {
            string plainText;

            using (var aesAlg = Aes.Create())
            {
                aesAlg.Key = Convert.FromBase64String(KEY);
                aesAlg.IV = Convert.FromBase64String(IV);

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(encryptedValue)))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plainText = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return plainText;
        }      
    }
}