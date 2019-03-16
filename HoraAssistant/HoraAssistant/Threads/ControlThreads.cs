using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace HoraAssistant{
    public static class ControlThreads{
        private static Dictionary<string, Thread> ArrThread = new Dictionary<string, Thread>();

        public static bool AddThread(string name, Thread thread) {
            bool answer = false;
            if ( answer = !ContaintName(name)){
                ArrThread.Add(name,thread);
            }
            return answer;
        }
        public static bool ContaintName(string name) {
            bool answer = false;
            if (ArrThread.ContainsKey(name))
                answer = true;
            return answer;
        }
        public static Thread GetThread(string name) {
            return ContaintName(name) ? ArrThread[name] : null;
        }
        public static void RemoveKey(string name) {
            if (ContaintName(name)) {
                ArrThread[name].Abort();
                ArrThread.Remove(name);
            }
        }
        public static void Clear() {
            if(ContaintName("XMLLoad"))
                ArrThread["XMLLoad"].Abort();
        }
    }
}
