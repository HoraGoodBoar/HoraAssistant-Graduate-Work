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
                return EventData.Events[EventData.IndexContains(NameEvent)].Start();
            }
            return new List<string>();
        }
    }
}
