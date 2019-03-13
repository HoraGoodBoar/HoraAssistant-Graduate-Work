using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HoraAssistant.Event{
    public class EventModel{
        public List<string> Tasks = new List<string>();
        public int Counter = 0;
        public int CounterTasks { get { return Tasks.Count; } }
        public string Name = "";
        public string Description = "";
        public EventModel(string name,string description,List<string> tasks) {
            Name = name;
            Description = description;
            Tasks = tasks;
        }
        public List<string> Start() {
            List<string> answer = new List<string>();
            
            return answer;
        }
    }
}
