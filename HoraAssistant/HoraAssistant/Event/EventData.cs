using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HoraAssistant{
    public static class EventData{
        public static List<EventModel> Events = new List<EventModel>();
        public static List<string> NameEvents = new List<string>();
        public static int CountEvents { get { return Events.Count; } }
        public static int CountTrue = 0;
        
        public static bool Contains(string Name) {
            bool answer = false;
            for (int i = 0; i < Events.Count; ++i)
                if (Events[i].Name == Name) {
                    answer = true;
                    break;
                }
            return answer;
        }
        public static int IndexContains(string Name) {
            int answer = -1;
            for (int i = 0; i < Events.Count; ++i)
                if (Events[i].Name == Name){
                    answer = i;
                    break;
                }
            return answer;
        }
        public static void LoadEvents() {
            XMLControl.LoadFileEvents();
        }
        public static void LoadNameEvents() {
            NameEvents.Add("Відкрити в Chrome");
            NameEvents.Add("Виключити/Деактивувати ПК");
        }
    }
}
