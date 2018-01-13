using WebDBApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace WebDBApp.Helpers
{
    public class SHA256HashHelper : IHashHelper
    {
        private string Compute(string text)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            StringBuilder hashString = new StringBuilder();
            foreach (byte x in hash)
            {
                hashString.Append(String.Format("{0:x2}", x));
            }
            return hashString.ToString();
        }

        public string Compute(string pwd, string salt)
        {
            return Compute(pwd + salt);
        }

        public string GetSalt()
        {
            RNGCryptoServiceProvider s = new RNGCryptoServiceProvider();
            var salt = new byte[1024];
            s.GetBytes(salt);
            return BitConverter.ToString(salt);
        }
    }
}