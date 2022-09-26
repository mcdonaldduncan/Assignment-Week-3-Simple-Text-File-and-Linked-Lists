using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InClass9_19.Constants;

namespace InClass9_19
{
    internal static class Import
    {
        public static List<Monster> RunImport()
        {
            List<Monster> monsters = new List<Monster>();
            List<string> temp = new List<string>();

            // StreamReader Usage example derived from https://www.c-sharpcorner.com/article/working-with-c-sharp-streamreader/
            using (StreamReader sr = new StreamReader(readPath))
            {
                string line;
                int lineNumber = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    if (lineNumber++ == 0)
                        continue;
                    temp.Add(line);
                }
                foreach (var item in temp)
                {
                    int i = 0;
                    string[] tempSplit = item.Split();
                    string n = tempSplit[i++];
                    int hp;
                    int mp;
                    int ap;
                    int def;

                    if (Int32.TryParse(tempSplit[i++], out int x))
                    {
                        hp = x;
                    }
                    else
                    {
                        hp = 0;
                        Console.WriteLine("Invalid file structure");
                    }
                    if (Int32.TryParse(tempSplit[i++], out int y))
                    {
                        mp = y;
                    }
                    else
                    {
                        mp = 0;
                        Console.WriteLine("Invalid file structure");
                    }
                    if (Int32.TryParse(tempSplit[i++], out int j))
                    {
                        ap = j;
                    }
                    else
                    {
                        ap = 0;
                        Console.WriteLine("Invalid file structure");
                    }
                    if (Int32.TryParse(tempSplit[i++], out int k))
                    {
                        def = x;
                    }
                    else
                    {
                        def = 0;
                        Console.WriteLine("Invalid file structure");
                    }

                    Monster tempMonster = new Monster(n, hp, mp, ap, def);
                    monsters.Add(tempMonster);
                }
            }
            return monsters;
        }

    }
}
