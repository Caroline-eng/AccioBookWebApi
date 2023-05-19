using System.Security.Cryptography;

namespace AccioBook.CrossCutting.Criptografy
{
    public static class StringCryptografyExtensions
    {
        private const string KEY = "VGVzdGVDaGF2ZQ==";
        private const string IV = "VGVzdGVJVg==";

        public static string Encrypt(this string clearValue)
        {
            byte[] encrypted;

            using (var aes = Aes.Create())
            {
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

        //private static string AesDecryptStringFromBytes(byte[] cipherText, byte[] key, byte[] iv)
        //{
        //    string plainText;
        //    using (Aes aes = Aes.Create())
        //    {
        //        aes.Key = key;
        //        aes.IV = iv;

        //        using (MemoryStream memoryStream = new MemoryStream(cipherText))
        //        using (ICryptoTransform decryptor = aes.CreateDecryptor())
        //        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
        //        using (StreamReader streamReader = new StreamReader(cryptoStream))
        //            plainText = streamReader.ReadToEnd();
        //    }
        //    return plainText;
        //}

        //private static byte[] AesEncryptStringToBytes(string plaintText, byte[] key, byte[] iv)
        //{
        //    byte[] encrypted;
        //    using (Aes aes = Aes.Create())
        //    {
        //        aes.Key = key;
        //        aes.IV = iv;

        //        using (MemoryStream memoryStream = new MemoryStream())
        //        {
        //            using (ICryptoTransform encryptor = aes.CreateEncryptor())
        //            using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
        //            using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
        //            {
        //                streamWriter.Write(plaintText);
        //            }
        //            encrypted = memoryStream.ToArray();
        //        }
        //    }
        //    return encrypted;
        //}

        //private static byte[] CreateKey(string encriptKey, int keyBytes = 32)
        //{
        //    byte[] salt = new byte[] { 50, 69, 71, 75, 65, 69, 72, 61 };
        //    int iterations = 300;
        //    var keyGenerator = new Rfc2898DeriveBytes(encriptKey, salt, iterations);
        //    return keyGenerator.GetBytes(keyBytes);
        //}
    }
}