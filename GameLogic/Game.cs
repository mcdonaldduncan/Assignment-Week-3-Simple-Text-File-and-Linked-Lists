using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InClass9_19.Import;
using static InClass9_19.FileProcess.Export;

namespace InClass9_19.GameLogic
{
    internal class Game
    {
        List<Monster> monsters = new List<Monster>();
        List<Encounter> encounters = new List<Encounter>();
        List<DoublyNode> doublyNodes = new List<DoublyNode>();

        int maxTurns;

        public void RunGame()
        {
            Monster player = SetUpGame();

            int currentTurn = 0;

            while (CanContinue(player))
            {
                Encounter currentEncounter;
                Console.WriteLine("Enter the name of the location you would like to visit" + Environment.NewLine);

                Console.WriteLine("Options:");
                foreach (var item in encounters)
                {
                    Console.WriteLine(item.name);
                }

                Console.WriteLine(Environment.NewLine);

                currentEncounter = GetEncounterFromInput();
                DoublyNode newNode = ProcessEncounter(currentEncounter, player, currentTurn);
                doublyNodes.Add(newNode);

                #region Unused
                // This line ends the game when the user is defeated, it does not end automatically after one, only if you lose.
                // Removed to meet modified requirements
                //if (player.SumStats() < currentEncounter.monster.SumStats())
                //{
                //    player.HP = 0;
                //}
                #endregion

                encounters.Remove(currentEncounter);
                currentTurn++;
            }

            LinkNodes();

            RunExport(doublyNodes[0]);
        }

        void LinkNodes()
        {
            for (int i = 0; i < doublyNodes.Count; i++)
            {
                if (i + 1 < doublyNodes.Count)
                {
                    doublyNodes[i].next = doublyNodes[i + 1];
                }
                if (i != 0)
                {
                    doublyNodes[i].prev = doublyNodes[i - 1];
                }
            }
        }

        Monster SetUpGame()
        {
            Console.WriteLine("Enter your name!");
            string newName = Console.ReadLine() ?? "Null";
            Monster player = new Monster(newName);

            monsters = RunImport();

            foreach (var item in monsters)
            {
                Encounter encounter = new Encounter(item);
                encounters.Add(encounter);

            }

            maxTurns = encounters.Count - 1;

            return player;
        }

        DoublyNode ProcessEncounter(Encounter encounter, Monster player, int turn)
        {
            Console.WriteLine($"You are now exploring {encounter.name}");
            Console.WriteLine($"You have encountered a {encounter.monster.Name}");

            int enemyTotal = encounter.monster.SumStats();
            int playerTotal = player.SumStats();

            Console.WriteLine($"Player Total: {playerTotal}, Enemy Total: {enemyTotal}");

            string result = $"You({player.Name}) encountered a {encounter.monster.Name} in the {encounter.name} and emerged {TestMonsterTotals(playerTotal, enemyTotal)}!";

            Console.WriteLine(result);

            if (turn == 0)
            {
                DoublyNode temp = new DoublyNode(result, true, false);
                return temp;
            }
            else
            {
                if (playerTotal >= enemyTotal && turn < maxTurns)
                {
                    DoublyNode temp = new DoublyNode(result, false, false);
                    return temp;
                }
                else
                {
                    DoublyNode temp = new DoublyNode(result, false, true);
                    return temp;
                }
            }
        }

        string TestMonsterTotals(int playerStats, int enemyStats)
        {
            string temp;
            if (playerStats >= enemyStats)
            {
                temp = "victorious";
            }
            else
            {
                temp = "defeated";
            }
            return temp;
        }

        Encounter GetEncounterFromInput()
        {
            string input = InputToLower();
            var current = encounters.FirstOrDefault(x => x.name.ToLower() == input);
            if (current == null)
            {
                Console.WriteLine("Please enter one of the names listed above");
                current = GetEncounterFromInput();
            }
            return current;
        }

        bool CanContinue(Monster player)
        {
            return encounters.Count > 0 && player.HP > 0;
        }

        string InputToLower()
        {
            string playerInput = Console.ReadLine()?.ToLower() ?? "Null";
            return playerInput;
        }
    }
}
