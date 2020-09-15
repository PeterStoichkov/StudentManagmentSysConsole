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
        public static void Render(OutputBox outBox)
        {
            RenderBox.Render(outBox);
            string text = outBox.Text;
            int startPosX = outBox.TopLeft.PosX + 1;
            int startPosY = outBox.TopLeft.PosY + 1;;

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            for (int i = 0; i < text.Length; i++)
            {
                Console.SetCursorPosition(startPosX, startPosY);
                Console.Write(text[i]);
                if (startPosX == outBox.Width + outBox.TopLeft.PosX - 1)
                {
                    startPosY++;
                    startPosX = outBox.TopLeft.PosX + 1;
                }
                else startPosX++;
            }
        }
    }
}
