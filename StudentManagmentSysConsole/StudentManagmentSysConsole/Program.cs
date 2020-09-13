using StudentManagmentSysConsole.Controller;
using StudentManagmentSysConsole.Model;
using StudentManagmentSysConsole.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagmentSysConsole
{

    class Program
    {
        // Moved all code to the app as i had problems with the static method
        static void Main(string[] args)
        {
            Application app = new Application();
            app.Start();

        }
    }
}
