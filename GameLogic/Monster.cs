using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InClass9_19
{
    internal class Monster
    {
        internal string Name;
        internal int HP;
        internal int MP;
        internal int AP;
        internal int Def;

        private Random R = new Random();

        // If you want to experiment with different results, tweak the random values assigned to the player monster
        public Monster(string name)
        {
            Name = name;
            HP = R.Next(150, 300);
            MP = R.Next(50, 150);
            AP = R.Next(50, 150);
            Def = R.Next(50, 150);
        }

        public Monster(string name, int hP, int mP, int aP, int def)
        {
            Name = name;
            HP = hP;
            MP = mP;
            AP = aP;
            Def = def;
        }

        public int SumStats()
        {
            return HP + MP + AP + Def;
        }
    }
}
