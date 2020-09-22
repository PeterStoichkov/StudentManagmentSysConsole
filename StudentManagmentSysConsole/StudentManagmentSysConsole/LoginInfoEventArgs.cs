using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagmentSysConsole
{
    public class LoginInfoEventArgs : EventArgs
    {
        public string Password { get; set; }
        public string Username { get; set; }
    }
}
