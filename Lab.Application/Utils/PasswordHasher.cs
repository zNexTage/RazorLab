using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace Lab.Application.Utils
{
    public class PasswordHasher
    {
        /// <summary>
        /// Criptografa uma senha utilizando o algoritmo sha256.
        /// </summary>
        /// <param name="password"></param>        
        /// <returns></returns>
        public static string Encrypt(string password)
        {            
            var bytes = Encoding.ASCII.GetBytes(password);

            var data = SHA256.HashData(bytes);

            return Convert.ToBase64String(data);
        }
    }
}
