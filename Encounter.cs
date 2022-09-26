using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InClass9_19.NameBank;

namespace InClass9_19
{
    internal class Encounter
    {
        public string name;
        public Monster monster;
        private Random R = new Random();

        public Encounter(Monster m)
        {
            monster = m;
            int nameIndex = R.Next(0, nameBank.Count);
            name = nameBank[nameIndex];
            nameBank.RemoveAt(nameIndex);
        }
    }
}
