using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DayOneWindowsClient.Models
{
    public interface IPasswordVerifier
    {
        bool VerifyPassword(string inputPassword);
    }
}
