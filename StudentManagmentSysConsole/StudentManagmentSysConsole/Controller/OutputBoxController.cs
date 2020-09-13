using StudentManagmentSysConsole.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagmentSysConsole.Controller
{
    class OutputBoxController
    {
        private OutputBox ouBox;

        public OutputBoxController(OutputBox ouBox)
        {
            this.ouBox = ouBox;
        }

        public void FillOutputBox(string text)
        {
            this.ouBox.Text = text;
        }
        public void ClearOutputBox(object sender, KeyEventArgs e)
        {
            string text = "";
            for(int i = 0; i <= this.ouBox.Text.Length; i++) text += " ";
            this.ouBox.Text = text;
        }
    }
}
