using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBGame
{
    class Room
    {
        public string description;
        public Room(string r)
        {
            description = r;
        }
        public bool GetCommand(string[] a)
        {
            if (a[0] == "look")
            {
                Console.WriteLine(description);
                return true;
            }
            return false;
        }
    }
}
