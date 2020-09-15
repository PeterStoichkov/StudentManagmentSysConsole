using StudentManagmentSysConsole.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StudentManagmentSysConsole.View
{
    static class RenderBox
    {
        public static void Render(Box box)
        {
            char symbol = '+';
            int startWidth = box.TopLeft.PosX;
            int startHeight = box.TopLeft.PosY;

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            //Render the top and bottom boarder
            for (int i = startWidth; i <= box.Width + startWidth; i++)
            {
                Console.SetCursorPosition(i, startHeight);
                Console.Write(symbol);
                Console.SetCursorPosition(i, startHeight + box.Height);
                Console.Write(symbol);
                if (i == box.Width + startWidth - 1) symbol = '+';
                else symbol = '-';
            }
            // Render the left and right boarder
            symbol = '|';
            for(int i = startHeight + 1; i <= box.Height + startHeight - 1; i++)
            {
                Console.SetCursorPosition(startWidth, i);
                Console.Write(symbol);
                Console.SetCursorPosition(startWidth + box.Width, i);
                Console.Write(symbol);
            }
        }
    }
}
