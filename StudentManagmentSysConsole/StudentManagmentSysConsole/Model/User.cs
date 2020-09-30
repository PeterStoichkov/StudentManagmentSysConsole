using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagmentSysConsole.Model
{
    public class User
    {
        public string Password { get; set; }

        public string Username { get; set; }

        public string LetterID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int FieldID { get; set; }

        public string Subject { get; set; }


        // Just to test if i have passed the user correctly
        public virtual string DisplayInfo()
        {

            return String.Format("Firstname: {0}, Lastname: {1}, Username: {2}, Password: {3}, LetterID: {4}" +
                ",FieldID: {5},Subject: {6}", FirstName, LastName, Username, Password, LetterID, FieldID, Subject); 
        }
    }
}
