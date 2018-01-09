using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminLayout.Services
{
    public interface IEncryptor
    {
        string Hash(string PlainText);
    }
}