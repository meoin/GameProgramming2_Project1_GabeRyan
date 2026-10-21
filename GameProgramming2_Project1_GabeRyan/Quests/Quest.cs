using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgramming2_Project1_GabeRyan.Quests
{
    internal class Quest
    {
        private EventType _eventType;
        public string Description { get; }
        public int Goal { get; }
        public int Progress { get; private set; }
        public bool Complete { get; private set; }

        public Quest(EventType eventType, int goal, string description)
        {
            Description = description;
            _eventType = eventType;
            Goal = goal;
            Progress = 0;
            Complete = false;

            EventBus.Subscribe(_eventType, IncrementProgress);
        }

        private void IncrementProgress()
        {
            Progress++;
            if (Progress >= Goal)
            {
                EventBus.Unsubscribe(_eventType, IncrementProgress);

                Complete = true;
            }
        }
    }
}
