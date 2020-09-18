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
        public static void Render(Box box, Point topLeft, int boxWidth, int boxHeight)
        {
            char symbol = '+';
            int startWidth = topLeft.PosX;
            int startHeight = topLeft.PosY;

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            //Render the top and bottom boarder
            for (int i = startWidth; i <= boxWidth + startWidth; i++)
            {
                Console.SetCursorPosition(i, startHeight);
                Console.Write(symbol);
                Console.SetCursorPosition(i, startHeight + boxHeight);
                Console.Write(symbol);
                if (i == boxWidth + startWidth - 1) symbol = '+';
                else symbol = '-';
            }
            // Render the left and right boarder
            symbol = '|';
            for(int i = startHeight + 1; i <= boxHeight + startHeight - 1; i++)
            {
                Console.SetCursorPosition(startWidth, i);
                Console.Write(symbol);
                Console.SetCursorPosition(startWidth + boxWidth, i);
                Console.Write(symbol);
            }
            // Change props if they differ from params
            if(box.Height != boxHeight || box.TopLeft.PosX != topLeft.PosX
                || box.TopLeft.PosY != topLeft.PosY || box.Width != boxWidth) {
                box.ChangeProps(topLeft, boxHeight, boxWidth);
            }
        }
    }
}
