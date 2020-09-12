using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagmentSysConsole
{
    class Input
    {
        public bool isKeyAvailable()
        {
            return Console.KeyAvailable;
        }

        public ConsoleKeyInfo GetKey()
        {
            return Console.ReadKey(true);
        }

        // May not come in use
        public string GetString()
        {
            return Console.ReadLine();
        }
    }
}
