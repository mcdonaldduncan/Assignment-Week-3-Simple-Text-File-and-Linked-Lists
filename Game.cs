using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InClass9_19.Import;
using static InClass9_19.Export;
using static InClass9_19.Printing;

namespace InClass9_19
{
    internal class Game
    {
        List<Monster> monsters = new List<Monster>();
        List<Encounter> encounters = new List<Encounter>();
        List<DoublyNode> doublyNodes = new List<DoublyNode>();

        int maxTurns;
        
        public void RunGame()
        {
            Print("Enter your name!");
            string newName = Console.ReadLine();
            Monster player = new Monster(newName);
            int currentTurn = 0;
            monsters = RunImport();
            
            foreach (var item in monsters)
            {
                Encounter encounter = new Encounter(item);
                encounters.Add(encounter);
                
            }
            
            maxTurns = encounters.Count - 1;
            
            while (CanContinue(player))
            {
                Encounter currentEncounter;
                Print("Enter the name of the location you would like to visit");
                Print();
                Print("Options:");
                foreach (var item in encounters)
                {
                    Print(item.name);
                }
                Print();
                currentEncounter = GetEncounterFromInput();
                DoublyNode newNode = ProcessEncounter(currentEncounter, player, currentTurn);
                doublyNodes.Add(newNode);
                // This line ends the game when the user is defeated, it does not end automatically after one, only if you lose.
                // Removed to meet modified requirements
                //if (player.SumStats() < currentEncounter.monster.SumStats())
                //{
                //    player.HP = 0;
                //}
                encounters.Remove(currentEncounter);
                currentTurn++;
                
            }

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

            RunExport(doublyNodes[0]);
        }
        
        DoublyNode ProcessEncounter(Encounter encounter, Monster player, int turn)
        {
            Print($"You are now exploring {encounter.name}");
            Print($"You have encountered a {encounter.monster.Name}");
            int enemyTotal = encounter.monster.SumStats();
            int playerTotal = player.SumStats();
            Print($"Player Total: {playerTotal}, Enemy Total: {enemyTotal}");
            string result = $"You({player.Name}) encountered a {encounter.monster.Name} in the {encounter.name} and emerged {TestMonsterTotals(playerTotal, enemyTotal)}!";
            Print(result);

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
                Print("Please enter one of the names listed above");
                current = GetEncounterFromInput();
            }
            return current;
        }
        
        bool CanContinue(Monster player)
        {
            return encounters.Count > 0 && player.HP > 0;
        }
    }
}
