using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgramming2_Project1_GabeRyan
{
    internal enum EventType 
    {
        EnemyDied,
        ScorePickedUp,
        HealthPickedUp,
        StepTaken
    }

    internal static class EventBus
    {
        private static Dictionary<EventType, Action> Events = new Dictionary<EventType, Action>();

        public static void Subscribe(EventType type, Action listener)
        {
            if (!Events.ContainsKey(type)) Events[type] = delegate { };
            Events[type] += listener;
        }

        public static void Unsubscribe(EventType type, Action listener)
        {
            if (Events.ContainsKey(type)) Events[type] -= listener;
        }

        public static void Invoke(EventType type)
        {
            if (Events.ContainsKey(type)) Events[type]?.Invoke();
        }
    }
}
