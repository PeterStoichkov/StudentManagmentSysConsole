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

        public Teacher(string password, string username, string letterID,
                    string firstName, string lastName, int fieldID, string subject)
            : base(password, username, letterID, firstName, lastName, fieldID, subject)
        {

        }

        public override string DisplayInfo()
        {
            return base.DisplayInfo();
        }
    }
}
