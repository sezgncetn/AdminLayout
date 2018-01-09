using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace AdminLayout.Services
{
    public class Md5HashProvider: IEncryptor
    {
        //MD5 Şifreleme metodu
        public string Hash(string PlainText)
        {
            MD5CryptoServiceProvider myprovider = new MD5CryptoServiceProvider();
            byte[] data = myprovider.ComputeHash(Encoding.UTF8.GetBytes(PlainText));

            StringBuilder s = new StringBuilder();
            foreach (var item in data)
            {
                //hexadecimal 16'lık sayı sistemi
                s.Append(item.ToString("X2"));
            }
            return s.ToString();
        }
    }
}