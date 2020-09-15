using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagmentSysConsole.View
{
    static class RenderTime
    {
        public static void Render(int posX, int posY, Timer timer)
        {
            Console.SetCursorPosition(posX, posY);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(timer.ReturnTime().Substring(0, 14) + " " +
                timer.ReturnTime().Substring(18, 2));
        }
    }
}
