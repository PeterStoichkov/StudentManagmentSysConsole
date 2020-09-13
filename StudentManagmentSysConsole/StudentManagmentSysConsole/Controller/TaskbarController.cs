using StudentManagmentSysConsole.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagmentSysConsole.Controller
{
    class TaskbarController
    {
        private Taskbar taskbar;
        
        public TaskbarController(Taskbar taskbar)
        {
            this.taskbar = taskbar;
        }
        // This method deals with the business logic which button is selected 
        public void ChangeSelect(object sender, KeyEventArgs e)
        {
            int currentPos = FindCurrentPos(taskbar);
            List<byte> state = taskbar.State;
            int lastPos = state.Count - 1;
            switch (e.Cki.Key)
            {
                case ConsoleKey.LeftArrow:
                    if(currentPos == 0) {
                        state[0] = 0; state[lastPos] = 1;
                    } else {
                        state[currentPos] = 0; state[currentPos - 1] = 1;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if(currentPos == lastPos) {
                        state[lastPos] = 0; state[0] = 1;
                    } else {
                        state[currentPos] = 0; state[currentPos + 1] = 1;
                    }
                    break;
            }
        }

        // Finds the currunt button selected
        private int FindCurrentPos(Taskbar taskbar)
        {
            int pos = 0;
            for(int i = 0; i < taskbar.State.Count; i++)
            {
                if(taskbar.State[i] == 1)
                {
                    pos = i;
                    break;
                }
            }
            return pos;
        }
    }
}
