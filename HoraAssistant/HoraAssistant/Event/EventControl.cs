using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HoraAssistant{
    public static class EventControl {
        public static void LoadData() {
            EventData.LoadEvents();
            EventData.LoadNameEvents();
        }
        public static List<string> StartEvent(string NameEvent) {
           
            if (EventData.Contains(NameEvent)){
                ++EventData.CountTrue;
                List<string> answer = new List<string>();
                List<int> indexs = EventData.IndexsContains(NameEvent);
                for (int i = 0; i < indexs.Count; ++i)
                    answer.AddRange(EventData.Events[indexs[i]].Start());
                return answer;
            }
            return new List<string>();
        }
        public static void DeleteFromName(string NameEvent) {
            for (int i = 0; i < EventData.Events.Count; ++i)
                if (EventData.Events[i].Name == NameEvent)
                    EventData.Events.RemoveAt(i--);
        }
    }
}
