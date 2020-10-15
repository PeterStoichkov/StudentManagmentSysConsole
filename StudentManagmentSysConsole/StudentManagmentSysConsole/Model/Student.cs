using System;
using System.CodeDom;
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

        public Student(string password, string username, string letterID,
                    string firstName, string lastName, int fieldID, string subject)
            :base(password, username, letterID, firstName, lastName, fieldID, subject)
        {

        }
        public override string DisplayInfo()
        {
            return base.DisplayInfo();
        }
    }
}
