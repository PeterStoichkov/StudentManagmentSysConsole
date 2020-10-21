using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace StudentManagmentSysConsole
{
    class InputFilter
    {
        private string currentInput;
        // the action byte will be used to differentiate between what the action is
        // and therefore how to filter it
        // 1. Username / Password / studentCommand - A-Z, a-z, 0-9
        // 2. Command  -  A-Z, a-z, 0-9, '-', ' '  

        public string GetValidatedInput(string currentInput, byte action)
        {
            this.currentInput = currentInput;
            bool valid = isValid(currentInput, action);

            if (valid)
            {
                this.currentInput = TrimCommand(currentInput);
                return this.currentInput;
            }
            else
            {
                return null;
            }
           
        }
        private bool isValid(string currentInput, byte action)
        {
            if(currentInput != null)
            {
                bool valid = false;
                switch (action)
                {
                    case 1:
                        for (int i = 0; i < currentInput.Length; i++)
                        {
                            char letter = currentInput[i]; int letterI = (int)letter;
                            if ((letterI < 97 || letterI > 122) && (letterI < 65 || letterI > 90))
                            {
                                if (letterI < 48 || letterI > 57)
                                {
                                    valid = false;
                                    break;
                                }
                            }
                            else valid = true;
                        }
                        break;
                    case 2:
                        currentInput = TrimCommand(currentInput);
                        for (int i = 0; i < currentInput.Length; i++)
                        {
                            char letter = currentInput[i]; int letterI = (int)letter;
                            if ((letterI < 97 || letterI > 122) && (letterI < 65 || letterI > 90))
                            {
                                if (letterI < 48 || letterI > 57)
                                {
                                    if (!(letterI == 32 || letterI == 45))
                                    {
                                        valid = false;
                                        break;
                                    }
                                }
                            }
                            else valid = true;
                        }
                        break;
                }
                return valid;
            }
            return false;
        }


        private string TrimCommand(string command)
        {
            string[] splitCommand = command.Split(' ');
            command = "";
            for(int i = 0; i < splitCommand.Length; i++)
            {
                if(splitCommand[i] != "")
                {
                    command += splitCommand[i].Trim() + " ";
                }
            }
            return command.Trim();
        }

        public void SetInput(string input)
        {
            currentInput = input;
        }
    }
}
