using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagmentSysConsole.Model
{
    class Student : User 
    {
        public List<string> Grades { get; set; }

        public string Teacher { get; set; }

    }
}
