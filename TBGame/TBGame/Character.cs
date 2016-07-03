using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBGame
{
    
    class Character
    {
        public Dictionary<string, Item> bag = new Dictionary<string, Item>();
        public string name;
        public string pronoun;
        public Character(string n,string p)
        {
            name = n;
            pronoun = p;
        }
        

    }
    class Questions : Dictionary<string, Questions>
    {
        public string answer;
        public Questions(string a, Dictionary<string, Questions> q) : base(q)
        {
            answer = a;
        }
    }
    class NPC : Character
    {
        public Questions questions;
        public NPC(string n, string p) : base(n, p) { }
    }
}
