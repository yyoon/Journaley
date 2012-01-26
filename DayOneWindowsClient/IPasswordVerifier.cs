using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DayOneWindowsClient
{
    public interface IPasswordVerifier
    {
        bool VerifyPassword(string inputPassword);
    }
}
