using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace StudentManagmentSysConsole.Controller
{
    class StudentDBController
    {
        private OleDbConnection aConnection;
        private string ReturnInfo;
        public StudentDBController()
        {
            aConnection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:" +
                "\\Users\\peter\\source\\repos\\StudentManagmentSysConsole\\StudentManagmentSysConsole\\StudentManagmentSysConsole\\Data\\StudentManSysDB.accdb;" +
                "Persist Security Info=True");
        }

        public void StudentRequestEventHandler(object sender, StudentInfoEventArgs e)
        {
            
            try
            {
                OleDbCommand aCommand = new OleDbCommand(e.Query, aConnection);
                aConnection.Open();
                OleDbDataReader aReader = aCommand.ExecuteReader();
                switch (e.RawInput)
                {
                    case "G":
                        ReturnInfo += string.Format("Grades :");
                        while (aReader.Read())
                        {
                            ReturnInfo += string.Format("{0}, ", aReader.GetString(1));
                        }
                        break;
                    case "S":
                        while (aReader.Read())
                        {
                            ReturnInfo += string.Format("Subject : {0}", aReader.GetString(3));
                        }
                        break;
                    case "T":
                        while (aReader.Read())
                        {
                            ReturnInfo += string.Format("Teacher : {0}", aReader.GetString(4));
                        }
                        break;
                    case "A":
                        
                        while (aReader.Read())
                        {
                            ReturnInfo += string.Format("Teacher : {0}, Subject : {1}, Grades : ", aReader.GetString(4), aReader.GetString(3));
                        }
                        aReader.Close();
                        aConnection.Close();
                        
                        aCommand = new OleDbCommand(String.Format("SELECT * FROM Grades WHERE student = '{0}'", e.User.FirstName + " " + e.User.LastName), aConnection);
                        aConnection.Open();
                        aReader = aCommand.ExecuteReader();

                        while (aReader.Read())
                        {
                            ReturnInfo += string.Format("{0}, ", aReader.GetString(1));
                        }
                        break;
                }
                aReader.Close();
                aConnection.Close();
            }
            catch (OleDbException Ole)
            {
                Console.WriteLine("Error: {0}", Ole.Errors[0].Message);
                aConnection.Close();
            }
        }

        public string ReturnOperaionResult()
        {
            if (ReturnInfo != null)
            {
                return ReturnInfo;
            }
            else
            {
                return "Operation faild!";
            }
        }
        public void NullOperationResult()
        {
            ReturnInfo = null;
        }
    }
}
