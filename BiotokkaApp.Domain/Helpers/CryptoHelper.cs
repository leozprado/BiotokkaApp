using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace BiotokkaApp.Domain.Helpers
{
    public static class CryptoHelper
    {
        /// <summary>
        /// Método para criptografar uma senha utilizando o algoritmo SHA256
        /// </summary>
        /// <param name="senha">Senha em texto puro</param>
        /// <returns>Senha criptografada</returns>
        public static string ToSha256(string input)
        {
            if (string.IsNullOrEmpty(input)) return string.Empty;
            using (var sha = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(input); var hash = sha.ComputeHash(bytes);
                var sb = new StringBuilder(); foreach (var b in hash) sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }

    }
}
