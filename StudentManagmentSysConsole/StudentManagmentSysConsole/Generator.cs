using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagmentSysConsole
{
    static class Generator
    {
        public static string GenPass()
        {
            string pass = "";
            Random rnd = new Random();
            byte type;
            int pos;
            for (int i = 0; i < 8; i++)
            {
                type = (byte)rnd.Next(0, 3);
                switch (type)
                {
                    case 0:
                        pos = rnd.Next(0, 10);
                        pass += pos.ToString();
                        break;
                    case 1:
                        pos = rnd.Next(65, 91);
                        pass += (char)pos;
                        break;
                    case 2:
                        pos = rnd.Next(97, 123);
                        pass += (char)pos;
                        break;
                }
            }
            return pass;
        }
        public static string GenNickname()
        {
            string nickname = "";
            Random rnd = new Random();
            int pos = rnd.Next(65, 91);
            nickname += (char)pos;

            for (int i = 1; i < 8; i++)
            {
                pos = rnd.Next(97, 123);
                nickname += (char)pos;
            }
            return nickname;
        }
    }
}
