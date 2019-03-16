using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HoraAssistant{
    public class EventModel{
        public List<object> Tasks = new List<object>();
        public int Counter = 0;
        public int CounterTasks { get { return Tasks.Count; } }
        public string Name = "";
        public string Description = "";
        public EventModel(string name,string description,List<object> tasks) {
            Name = name;
            Description = description;
            Tasks = tasks;
        }
        public EventModel() { }
        public List<string> Start() {
            List<string> answer = new List<string>();
            for (int i = 0; i < CounterTasks; ++i)
                answer.Add((Tasks[i] as ITaskFather).Start());
            return answer;
        }
    }
}
