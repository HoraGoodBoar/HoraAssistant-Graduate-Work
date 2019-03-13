using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HoraAssistant{
    public static class EventData{
        public static List<Event.EventModel> Events = new List<Event.EventModel>();
        public static List<string> NameEvents = new List<string>();
        public static int CountEvents { get { return Events.Count; } }
        
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
            Events.Add( new Event.EventModel( "Dima","Lol",new List<string>() { "Da","Lo"}));
            Events.Add(new Event.EventModel("asdsad", "Lol", new List<string>() { "Da", "Ld", "Lo", "Lo" }));
            Events.Add(new Event.EventModel("Dimssa", "Lol", new List<string>() { "Da", "Lo", "Dl" }));
            Events.Add(new Event.EventModel("Dimsadsada", "Lol", new List<string>() { "Da", "Ld", "Lo", "Lo", "Lo" }));
            Events.Add(new Event.EventModel("sadsadDima", "Lol", new List<string>() { "Da", "Ld", "Lo", "Lo", "Lo" }));
        }
        public static void LoadNameEvents() {
            NameEvents.Add("Da");
            NameEvents.Add("Lo");
            NameEvents.Add("Dl");
            NameEvents.Add("Ld");
        }
    }
}
