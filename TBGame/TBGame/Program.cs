using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBGame
{
    class Program
    {
        static public Room currentRoom;
        static public Character user;
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome");
            Console.WriteLine("What is your name?");
            string username = Console.ReadLine();
            Console.WriteLine("How do you want to be adressed?");
           
            string pronoun = Console.ReadLine();
            user = new Character(username,pronoun);
            Console.WriteLine("This is "+ user.name+", doesn't " +user.pronoun +" look fabulous today?");

            Room room0 = new Room("It is a 30 square meter room with red walls.");
            Room room1 = new Room("It is a 40 square meter room with green walls.");
            Room room2 = new Room("It is a 50 square meter room with blue walls.");
            room0.neighborrooms.Add("hall", room2);
            room2.neighborrooms.Add("outside", room0);

            Item leftsock = new Item("left sock");
            room0.roomitems.Add("left sock",leftsock );

            Item rightsock = new Item("right sock");
            room2.roomitems.Add("right sock", rightsock);

            NPC character0 = new NPC("Alice","she");
            character0.questions = new Questions(null, new Dictionary<string, Questions>{
                { "How are you?", new Questions("fine, you?",
                    new Dictionary<string, Questions> {
                    }) },
            });
            NPC character1 = new NPC("Bob", "he");
            room0.roompeople.Add("Alice", character0);
            room2.roompeople.Add("Bob", character1);

            currentRoom = room0;
            while (true)
            {
                string[] command = Console.ReadLine().Split(' ');
                Getcommand(command);
                
            }
            

        }
        static void Getcommand(string[] args)
        {
            if (args[0]== "exit") {
                Environment.Exit(0);
            }
            else if (args[0]== "inventory")
            {
                Console.WriteLine("The items in your bag are:");
                Console.WriteLine(String.Join(", ", user.bag.Keys.ToArray()));
            }
            else if (!currentRoom.GetCommand(args))
            {
                Console.WriteLine("This is not a valid command! Try again.");
            }

        }
    }
    
}
