using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminLayout.Services
{
    public interface IMessage
    {
        bool SendMessage(string subject, string message);
    }
}