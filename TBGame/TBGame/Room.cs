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
        public Dictionary<string,Room> neighborrooms = new Dictionary<string, Room>();

        public Room(string r)
        {
            description = r;
        }
        public bool GetCommand(string[] a)
        {
            if (a[0] == "look")
            {
                Console.WriteLine("The room looks like");
                Console.WriteLine(description);
                Console.WriteLine("The rooms you can visit from here are:");
                Console.WriteLine(String.Join(", ", neighborrooms.Keys));
                return true;
            }
            else if (a[0] == "go"&& a.Length==2 && neighborrooms.ContainsKey(a[1]))
            {
                string roomname = a[1];
                Room newroom = neighborrooms[roomname];
                Program.currentRoom = newroom;
                return true;
            }
            return false;
        }
    }
}
