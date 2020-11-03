using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace StudentManagmentSysConsole.Controller
{
    class TeacherDBController
    {
        private OleDbConnection aConnection;
        private string ReturnInfo;
        public TeacherDBController()
        {
            aConnection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:" +
                "\\Users\\peter\\source\\repos\\StudentManagmentSysConsole\\StudentManagmentSysConsole\\StudentManagmentSysConsole\\Data\\StudentManSysDB.accdb;" +
                "Persist Security Info=True");
        }

        public void TeacherRequestEventHandler(object sender, TeacherInfoEventArgs e)
        {
            switch (e.Action)
            {
                case 0:
                    try
                    {
                        OleDbCommand aCommand = new OleDbCommand(e.Query, aConnection);
                        aConnection.Open();
                        aCommand.ExecuteNonQuery();
                        aConnection.Close();
                        ReturnInfo = string.Format("Operation was successful, the change was made at {0}", DateTime.Now.ToString("g"));
                    }
                    catch (OleDbException Ole)
                    {
                        Console.WriteLine("Error: {0}", Ole.Errors[0].Message);
                        aConnection.Close();
                    }
                    break;
                case 1:
                    try
                    {
                        OleDbCommand aCommand = new OleDbCommand(e.Query, aConnection);
                        aConnection.Open();
                        OleDbDataReader aReader = aCommand.ExecuteReader();
                        while (aReader.Read())
                        {
                            ReturnInfo += string.Format("Name: {0}\n Subject: {1}\n Grades: {2}\n Teacher: {3}",
                                aReader.GetString(1) + aReader.GetString(2),
                                aReader.GetString(3), aReader.GetString(4), aReader.GetString(5));  
                        }
                        aReader.Close();
                        aConnection.Close();
                    }
                    catch (OleDbException Ole)
                    {
                        Console.WriteLine("Error: {0}", Ole.Errors[0].Message);
                        aConnection.Close();
                    }
                    break;
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
    }
}
