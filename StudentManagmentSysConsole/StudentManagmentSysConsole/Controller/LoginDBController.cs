using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace StudentManagmentSysConsole
{
    class LoginDBController
    {
        private OleDbConnection aConnection;

        public Application App { get; set; }

        public LoginDBController(Application app)
        {
            App = app;
            aConnection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:" +
                "\\Users\\peter\\source\\repos\\StudentManagmentSysConsole\\StudentManagmentSysConsole\\StudentManagmentSysConsole\\Data\\StudentManSysDB.accdb;" +
                "Persist Security Info=True");
        }

        public void LoginDBEvent(object sender, LoginInfoEventArgs e)
        {
           

            if (CheckTPassword(e) && CheckTUsrname(e))
            {
                CreateUserT(e);
                Console.Clear();
                App.BootstrapTeacherView(e.User);
                App.Start();
            }
            else if (CheckSPassword(e) && CheckSUsrname(e))
            {
                CreateUserS(e);
                Console.Clear();
                App.BootstrapStudentView(e.User);
                App.Start();
            }
            else
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - 10, Console.WindowHeight / 2 + 11);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("* Wrong username or password");
                Console.SetCursorPosition(0, 0);
                Console.ForegroundColor = ConsoleColor.White;

            }
        }
        
        public bool CheckTPassword(LoginInfoEventArgs e)
        {
            OleDbCommand aCommandPT = new OleDbCommand("SELECT * from Teachers", aConnection);
            bool valid = false;
            try
            {
                aConnection.Open();
                OleDbDataReader aReader = aCommandPT.ExecuteReader();
                while (aReader.Read())
                {
                    if(e.Password == aReader.GetString(6))
                    {
                        valid = true;
                        break;
                    }
                }

                aReader.Close();
                aConnection.Close();
            }
            catch (OleDbException eOl)
            {
                Console.WriteLine("Error: {0}", eOl.Errors[0].Message);
            }
            return valid;
        }

        public bool CheckTUsrname(LoginInfoEventArgs e)
        {
            OleDbCommand aCommandPT = new OleDbCommand("SELECT * from Teachers", aConnection);
            bool valid = false;
            try
            {
                aConnection.Open();
                OleDbDataReader aReader = aCommandPT.ExecuteReader();
                while (aReader.Read())
                {
                    if (e.Username == aReader.GetString(5))
                    {
                        valid = true;
                        break;
                    }
                }
                aReader.Close();
                aConnection.Close();
            }
            catch (OleDbException eOl)
            {
                Console.WriteLine("Error: {0}", eOl.Errors[0].Message);
            }
            return valid;
        }

        public bool CheckSPassword(LoginInfoEventArgs e)
        {
            OleDbCommand aCommandPT = new OleDbCommand("SELECT * from Students", aConnection);
            bool valid = false;
            try
            {
                aConnection.Open();
                OleDbDataReader aReader = aCommandPT.ExecuteReader();
                while (aReader.Read())
                {
                    if (e.Password == aReader.GetString(7))
                    {
                        valid = true;
                        break;
                    }
                }

                aReader.Close();
                aConnection.Close();
            }
            catch (OleDbException eOl)
            {
                Console.WriteLine("Error: {0}", eOl.Errors[0].Message);
            }
            return valid;
        }

        public bool CheckSUsrname(LoginInfoEventArgs e)
        {
            OleDbCommand aCommandPT = new OleDbCommand("SELECT * from Students", aConnection);
            bool valid = false;
            try
            {
                aConnection.Open();
                OleDbDataReader aReader = aCommandPT.ExecuteReader();
                while (aReader.Read())
                {
                    if (e.Username == aReader.GetString(6))
                    {
                        valid = true;
                        break;
                    }
                }
                aReader.Close();
                aConnection.Close();
            }
            catch (OleDbException eOl)
            {
                Console.WriteLine("Error: {0}", eOl.Errors[0].Message);
            }
            return valid;
        }

        public void CreateUserT(LoginInfoEventArgs e)
        {
            OleDbCommand aCommand = new OleDbCommand("SELECT * from Teachers" +
                                        " WHERE username = @par1 AND `password` = @par2", aConnection);
            aCommand.Parameters.AddRange(new[] {
                    new OleDbParameter("@par1", e.Username),
                    new OleDbParameter("@par2", e.Password)
                });

            try
            {
                aConnection.Open();
                
                OleDbDataReader aReader = aCommand.ExecuteReader();
                while (aReader.Read())
                {
                    

                    int fieldID = aReader.GetInt32(0);
                    string firstName = aReader.GetString(1);
                    string lastName = aReader.GetString(2);
                    string subject = aReader.GetString(3);
                    string letterID = aReader.GetString(7);

                    e.User = new Model.User(e.Password, e.Username, letterID,
                        firstName, lastName, fieldID, subject);
                }   
                aReader.Close();
                aConnection.Close();
            }
            catch (OleDbException ex)
            {
                Console.WriteLine("Error: {0}", ex.Errors[0].Message);
            }         
        }

        public void CreateUserS(LoginInfoEventArgs e)
        {
            OleDbCommand aCommand = new OleDbCommand("SELECT * from Students" +
                                        " WHERE username = @par1 AND `password` = @par2", aConnection);
            aCommand.Parameters.AddRange(new[] {
                    new OleDbParameter("@par1", e.Username),
                    new OleDbParameter("@par2", e.Password)
                });

            try
            {
                aConnection.Open();
                OleDbDataReader aReader = aCommand.ExecuteReader();
                while (aReader.Read())
                {
                    

                    int fieldID = aReader.GetInt32(0);
                    string firstName = aReader.GetString(1);
                    string lastName = aReader.GetString(2);
                    string subject = aReader.GetString(3);
                    string letterID = aReader.GetString(8);

                    e.User = new Model.User(e.Password, e.Username, letterID,
                        firstName, lastName, fieldID, subject);
                }
                aReader.Close();
                aConnection.Close();
            }
            catch (OleDbException ex)
            {
                Console.WriteLine("Error: {0}", ex.Errors[0].Message);
            }
        }
    }
}
