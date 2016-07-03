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
        public Dictionary<string, Item> roomitems = new Dictionary<string, Item>();
        public Dictionary<string, NPC> roompeople = new Dictionary<string, NPC>();

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
                Console.WriteLine("The items in the room are:");
                Console.WriteLine(String.Join(", ", roomitems.Keys.ToArray()));
                Console.WriteLine("The rooms you can visit from here are:");
                Console.WriteLine(String.Join(", ", neighborrooms.Keys.ToArray()));
                Console.WriteLine("The people you can talk to in this room:");
                Console.WriteLine(String.Join(", ", roompeople.Keys.ToArray()));
                return true;
            }
            else if (a[0] == "go")
            {
                try
                {
                    string roomname = String.Join(" ", a.Skip(1));
                    Room newroom = neighborrooms[roomname];
                    Program.currentRoom = newroom;
                    Console.WriteLine("You enter " + roomname + " and look around.");
                    newroom.GetCommand(new[]{"look"});
                }
                catch (KeyNotFoundException e)
                {
                    Console.WriteLine("That room does not exist");
                }
                return true;

            }
            else if (a[0] == "pick")
            {
                try
                {
                    string itemname = String.Join(" ", a.Skip(1));
                    Program.user.bag.Add(itemname,roomitems[itemname]);
                    roomitems.Remove(itemname);
                    Console.WriteLine("You picked up " + itemname);

                }
                catch (KeyNotFoundException e)
                {
                    Console.WriteLine("That item does not exist");
                }
                return true;

            }
            else if (a[0] == "talk")
            {
                try
                {
                    string charactername = String.Join(" ", a.Skip(1));
                    NPC p = roompeople[charactername];
                    Questions questions = p.questions;
                    while (questions.Count > 0)
                    {
                        int i = 0;
                        foreach (var question in questions)
                        {
                            i++;
                            Console.WriteLine(i.ToString() + ") " + question.Key);
                        }
                        int key = Int32.Parse(Console.ReadLine());
                        Questions q = questions[questions.Keys.ToArray()[key-1]];
                        Console.WriteLine(q.answer);
                        questions = q;
                    }
                }
                catch (KeyNotFoundException e)
                {
                    Console.WriteLine("");
                }
                return true;

            }
            return false;
        }
    }
}
