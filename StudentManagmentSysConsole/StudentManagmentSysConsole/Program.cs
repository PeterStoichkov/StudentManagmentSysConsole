using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagmentSysConsole
{
    class Program
    {

        static void Main(string[] args)
        {
            Timer timer = new Timer();
            timer.Tick += (object sender, DateEventArgs e) => 
            { return String.Format(e.dateTime.ToString()); };
            while (true)
            {
                string time = "";
                time = timer.Start();
                Console.SetCursorPosition(40, 20);
                Console.WriteLine(time);
                System.Threading.Thread.Sleep(60);

            }
        }

    }
}
