using Microsoft.SqlServer.Server;
using StudentManagmentSysConsole.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagmentSysConsole
{
    class QueryCreator
    {
        private string Query { get; set; }

        public string Input { get; set; }

        public int State { get; set; }

        public User User { get; set; }

        public QueryCreator(User user)
        {
            User = user;
        }
        
        public string ReturnQuery()
        {             
            return Query;
        }

        public void CreateQuery(string input, int state)
        {
            string[] stringArray = input.Split(' ');
            Input = input;
            State = state;
            if(stringArray.Length > 2 && (stringArray[0] == "grade" || stringArray[0] == "student"))
            {
                switch (state)
                {
                    case 1:
                        switch (stringArray[0])
                        {
                            case "student":
                                Query =
                                    String.Format("INSERT INTO Students (firstname, lastname, subject, teacher, `username`, `password`, letterID)" +
                                                  "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', 'S')",
                                    stringArray[1], stringArray[2], User.Subject, User.FirstName + " " + User.LastName,
                                    Generator.GenPass(), Generator.GenNickname());
                                break;
                            case "grade":
                                Query =
                                    String.Format("INSERT INTO Grades (grade, `timestamp`, student, teacher)" +
                                   "VALUES ('{0}', '{1}', '{2}', '{3}')",
                                    stringArray.Last(), DateTime.Now.ToString(), stringArray[1] + " " + stringArray[2], User.FirstName + " " + User.LastName);
                                break;
                        }
                        break;

                    case 2:
                        switch (stringArray[0])
                        {
                            case "student":
                                Query =
                                    String.Format("UPDATE Students SET firstname = '{0}', lastname = '{1}'" +
                                    " WHERE firstname = '{2}' AND lastname = '{3}'",
                                    stringArray[3], stringArray[4], stringArray[1], stringArray[2]
                                    );
                                break;
                            case "grade":
                                Query =
                                    String.Format("UPDATE Grades SET grade = '{0}' WHERE student = '{1}'",
                                    stringArray[3], stringArray[1] + " " + stringArray[2]);
                                break;
                        }
                        break;
                    case 3:
                        switch (stringArray[0])
                        {
                            case "student":
                                Query =
                                    String.Format("DELETE FROM Students WHERE firstname = '{0}' AND lastname = '{1}'",
                                        stringArray[1], stringArray[2]
                                    );
                                break;
                            case "grade":
                                Query =
                                    String.Format("DELETE FROM Grades WHERE grade = '{0}' AND student = '{1}'",
                                        stringArray[3], stringArray[1] + " " + stringArray[2]
                                    );
                                break;
                        }
                        break;
                    case 4:
                        Query =
                            String.Format("SELECT * FROM Students WHERE firstname = '{0}' AND lastname = '{1}'",
                                        stringArray[1], stringArray[2]);
                        break;
                }
            }
        }

        public void CreateQuery(string input)
        {
            switch (input)
            {
                case "G":
                    Query = String.Format("SELECT * FROM Grades WHERE student = '{0} {1}'",
                        User.FirstName, User.LastName);
                    break;
                case "S":
                    Query = String.Format("SELECT * FROM Students WHERE firstname = '{0}' AND lastname = '{1}'",
                        User.FirstName, User.LastName);
                    break;
                case "T":
                    Query = String.Format("SELECT * FROM Students WHERE firstname = '{0}' AND lastname = '{1}'",
                        User.FirstName, User.LastName);
                    break;
                case "A":
                    Query = String.Format("SELECT * FROM Students WHERE firstname = '{0}' AND lastname = '{1}'" +
                                          "UNION" +
                                          "SELECT * FROM Grades WHERE student = '{0} {1}'",
                                            User.FirstName, User.LastName);
                    break;
            }
        }
        public void NullQeury()
        {
            Query = null;
        }
    }
}
