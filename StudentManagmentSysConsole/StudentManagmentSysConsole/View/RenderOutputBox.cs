using StudentManagmentSysConsole.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagmentSysConsole.View
{
    static class RenderOutputBox
    {
        public static void Render(OutputBox outBox, Point topLeft, int boxHeight, int boxWidth)
        {
            RenderBox.Render(outBox, topLeft, boxHeight, boxWidth);
            string text = outBox.Text;
            int startPosX = topLeft.PosX + 1;
            int startPosY = topLeft.PosY + 1;;

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            for (int i = 0; i < text.Length; i++)
            {
                Console.SetCursorPosition(startPosX, startPosY);
                Console.Write(text[i]);
                if (startPosX == boxWidth + topLeft.PosX - 1)
                {
                    startPosY++;
                    startPosX = topLeft.PosX + 1;
                }
                else startPosX++;
            }
        }
    }
}
