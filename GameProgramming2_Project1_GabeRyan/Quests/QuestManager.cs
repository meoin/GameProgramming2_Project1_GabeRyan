using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgramming2_Project1_GabeRyan.Quests
{
    internal class QuestManager
    {
        public List<Quest> Quests = new List<Quest>();

        public QuestManager() { }

        public void DisplayQuests(int xOffset, int yOffset) 
        {
            for (int i = 0; i < Quests.Count; i++)
            {
                Quest quest = Quests[i];

                Console.SetCursorPosition(xOffset, yOffset + i);
                Console.ForegroundColor = ConsoleColor.White;

                if (quest.Complete) Console.ForegroundColor = ConsoleColor.Green;

                Console.Write($"{i+1}. {quest.Description}: {quest.Progress}/{quest.Goal}");
            }
        }
    }
}
