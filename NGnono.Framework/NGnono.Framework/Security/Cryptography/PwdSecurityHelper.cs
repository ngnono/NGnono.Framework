using NGnono.Framework.Logger;
using System;
using System.Security.Cryptography;

namespace NGnono.Framework.Security.Cryptography
{
    /// <summary>
    /// 
    /// </summary>
    public static class PwdSecurityHelper
    {
        /// <summary>
        /// 编码
        /// </summary>
        /// <param name="pass"></param>
        /// <returns></returns>
        public static string ComputeHash(string pass)
        {
            //step1: create salt 
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            //step2: create pass hash
            var pbkdf2 = new Rfc2898DeriveBytes(pass, salt, 10000);
            //step3: combine hash and salt
            var hash = pbkdf2.GetBytes(20);
            var hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            //step4: base64 encode
            return Convert.ToBase64String(hashBytes);
        }

        /// <summary>
        /// 检查
        /// </summary>
        /// <param name="pass"></param>
        /// <param name="hashedPass"></param>
        /// <returns></returns>
        public static bool CheckEqual(string pass, string hashedPass)
        {
            /* Extract the bytes */
            byte[] hashBytes;
            try
            {
                hashBytes = Convert.FromBase64String(hashedPass);
            }
            catch (Exception ex)
            {
                var logger = LoggerManager.Current();
                logger.Error(ex);

                return false;
            }
            /* Get the salt */
            var salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            /* Compute the hash on the password the user entered */
            var pbkdf2 = new Rfc2898DeriveBytes(pass, salt, 10000);
            var hash = pbkdf2.GetBytes(20);
            /* Compare the results */
            for (var i = 0; i < 20; i++)
            {
                if (hashBytes[i + 16] != hash[i])
                    return false;
            }

            return true;
        }
    }
}
