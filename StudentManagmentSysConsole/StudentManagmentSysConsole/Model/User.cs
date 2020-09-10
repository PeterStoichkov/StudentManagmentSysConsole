using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagmentSysConsole.Model
{
    abstract class User
    {
        public string Password { get; set; }

        public string Username { get; set; }

        public Char LetterID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int FieldID { get; set; }

        public string Subject { get; set; }
    }
}
