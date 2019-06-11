using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using NAudio;
namespace HoraAssistant{
    public static class ControlRecording{
        public static void StartRecording() {
            if (!DataAssistant.IsRecording)
                RecordingSound.Start();
        }
        public static void StopRecording() {
            if (DataAssistant.IsRecording){
                RecordingSound.Stop();
            }
        }
    }
}
