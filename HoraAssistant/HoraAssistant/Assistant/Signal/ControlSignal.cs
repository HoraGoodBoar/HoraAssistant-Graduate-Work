using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HoraAssistant{
    public static class ControlSignal{
        public static void Start() {
            Parser.Start();
        }
        public static void Stop() {
            Parser.Stop();
        }
    }
}
