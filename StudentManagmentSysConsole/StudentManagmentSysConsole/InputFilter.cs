using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagmentSysConsole
{
    class InputFilter
    {
        private string currentInput;
        // the action byte will be used to differentiate between what the action is
        // and therefore how to filter it
        // 1. Username / Password / studentCommand - A-Z, a-z, 0-9
        // 2. Command  -  A-Z, a-z, 0-9, '-', ' '  

        public string GetInput(string currentInput, byte action)
        {
            this.currentInput = currentInput;
            CutInput();
            return this.currentInput;
        }
        private void CutInput()
        {

        }
    }
}
