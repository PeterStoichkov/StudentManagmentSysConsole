﻿using StudentManagmentSysConsole.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagmentSysConsole.Controller
{
    class InputBoxController
    {
        private InputBox ipBox;
        private string input;

        public InputBoxController(InputBox ipBox)
        {
            this.ipBox = ipBox; 
        }

        public void ChangeState(object sender, KeyEventArgs e)
        {
            switch (e.Cki.Key)
            {
                case ConsoleKey.I:
                    if (ipBox.Active)
                    {
                        int startPosX = ipBox.TopLeft.PosX + 1;
                        int startPosY = ipBox.TopLeft.PosY + 1;
                        Console.SetCursorPosition(startPosX, startPosY);
                        Console.Write(">");
                        input = Console.ReadLine();
                    }
                    else ipBox.Active = true;
                    break;
                case ConsoleKey.Enter:
                    if (ipBox.Active)
                    {
                        int startPosX = ipBox.TopLeft.PosX + 1;
                        int startPosY = ipBox.TopLeft.PosY + 1;
                        Console.SetCursorPosition(startPosX, startPosY);
                        string text = "";
                        for (int i = 0; i <= input.Length; i++) text += " ";
                        Console.WriteLine(text);
                        Console.SetCursorPosition(0, 0);
                        ipBox.Active = false;
                    }
                    break;
            }
        }
        public string GetInput() { return input; }
    }
}
