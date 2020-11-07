using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagmentSysConsole
{
    public class TeacherInfoEventArgs : EventArgs
    {
        public string Query { get; set; }
        // The action can be either 1 or 0 if 
        // 0 - we will only change the db i.e. Create, Update, Delete
        // 1 - we will give output meaning we will use aReadeer i.e. Retrive
        public int Action { get; set; }

        public string RawInput { get; set; }
    }
}
