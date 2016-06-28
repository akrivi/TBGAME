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
                Console.WriteLine(String.Join(", ", neighborrooms.Keys.ToArray()));
                return true;
            }
            else if (a[0] == "go")
            {
                try
                {
                    string roomname = a[1];
                    Room newroom = neighborrooms[roomname];
                    Program.currentRoom = newroom;
                    Console.WriteLine("You enter " + roomname + " and look around.");
                    GetCommand(new[]{"look"});
                }
                catch (KeyNotFoundException e)
                {
                    Console.WriteLine("That room does not exist");
                }
                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine("Specify a room: go <room>");
                }
                return true;

            }
            return false;
        }
    }
}
