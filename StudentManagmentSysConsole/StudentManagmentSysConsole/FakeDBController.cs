using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagmentSysConsole
{
    class FakeDBController
    {
        // Hard coded example to make the filtration and how we will switch between views
        private string passwordStudent = "password";
        private string passwordTeacher = "notPassword";

        private string usernameStudent = "eud12090";
        private string usernameTeacher = "eud13060";

        public Application App { get; set; }

        public FakeDBController(Application app)
        {
            App = app;
        }

        public string[] GetInfo(char idletter)
        {
            if (idletter == 's')
            {
                return new string[] { usernameStudent, passwordStudent };
            }
            else if (idletter == 't')
            {
                return new string[] { usernameTeacher, passwordTeacher };
            }
            else return null;
        }

        public void DBEvent(object sender, LoginInfoEventArgs e)
        {
            if(e.Password == passwordTeacher && e.Username == usernameTeacher)
            {
                Console.Clear();
                App.BootstrapTeacherView();
                App.Start();
            } else if (e.Password == passwordStudent && e.Username == usernameStudent)
            {
                Console.Clear();
                App.BootstrapStudentView();
                App.Start();
            } else
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - 10, Console.WindowHeight / 2 + 11);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("* Wrong username or password");
                Console.SetCursorPosition(0, 0);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
