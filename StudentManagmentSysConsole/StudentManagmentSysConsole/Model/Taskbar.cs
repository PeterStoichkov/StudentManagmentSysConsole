using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagmentSysConsole.Model
{
    // A custom taskbar as only one will be used but a ctor can be added for an excpantion
    class Taskbar
    {
        public List<byte> State { get; set; }
        
        public List<string> Text { get; set; }
        
        public List<char> Letter { get; set; }

        public Taskbar()
        {
            this.Text = new List<string> { "CREATE", "UPDATE", "DELETE", "RETRIVE" };
            this.State = new List<byte> { 1, 0, 0, 0};
            this.Letter = new List<char> { 'C', 'U', 'D', 'R' };
        }

        public int ReturnStateAsInt()
        {
            int state = 1;
            for (int i = 0; i < State.Count; i++)
            {
                if(State.ElementAt(i) == 1)
                {
                    break;
                }
                state++;
            }
            return state;
        }
    }
}
