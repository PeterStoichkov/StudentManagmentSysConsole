using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagmentSysConsole.Model
{
    class Teacher : User
    {
        public List<string> Students { get; set; }

    }
}
