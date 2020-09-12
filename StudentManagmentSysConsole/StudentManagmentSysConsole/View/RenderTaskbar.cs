using StudentManagmentSysConsole.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagmentSysConsole.View
{
    static class RenderTaskbar
    {
        public static void Render(Taskbar taskbar, int windowHeight)
        {
            Console.SetCursorPosition(windowHeight, 0);
            for(int i = 0; i < taskbar.Text.Count; i++)
            {
                if(taskbar.State.ElementAt(i) == 1)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
            }
            Console.SetCursorPosition(0, 0);
        }

        private static void SetColor(Taskbar taskbar)
        {

        }
    }
}
