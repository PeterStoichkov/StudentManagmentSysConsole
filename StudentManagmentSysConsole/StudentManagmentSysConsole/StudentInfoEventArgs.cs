using StudentManagmentSysConsole.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagmentSysConsole
{
    public class StudentInfoEventArgs
    {
        public string Query { get; set; }
        public string RawInput { get; set; }
        public User User { get; set; }
    }
}
