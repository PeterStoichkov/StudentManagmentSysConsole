using StudentManagmentSysConsole.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagmentSysConsole.View;

namespace StudentManagmentSysConsole.Controller
{
    class OutputBoxController
    {
        private OutputBox outBox;

        public OutputBoxController(OutputBox ouBox)
        {
            this.outBox = ouBox;
        }

        public void FillOutputBox(string text)
        {
            ClearOutputBox(this, new KeyEventArgs());
            RenderOutputBox.Render(outBox, outBox.TopLeft, outBox.Width, outBox.Height);
            this.outBox.Text = text;
        }
        public void ClearOutputBox(object sender, KeyEventArgs e)
        {
            string text = "";
            for(int i = 0; i <= (this.outBox.Height - 1)* (this.outBox.Width - 1); i++) text += " ";
            this.outBox.Text = text;
        }
    }
}
