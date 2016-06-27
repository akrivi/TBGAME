using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome");
            Console.WriteLine("What is your name?");
            string username = Console.ReadLine();
            Console.WriteLine("How do you want to be adressed?");
           
            string pronoun = Console.ReadLine();
            Character user = new Character(username,pronoun);
            Console.WriteLine("This is "+ user.name+", doesn't " +user.pronoun +" look fabulous today?");
            

            Console.ReadLine();

        }
    }
    
}
