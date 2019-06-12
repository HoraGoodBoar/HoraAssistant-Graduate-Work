using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NAudio;
using NAudio.Wave;
using System.Configuration;

namespace HoraAssistant{
    public static class RecordingSound {
        public static void Start() {
            DataAssistant.SetValuesListener();
            DataAssistant.SetValuesWriter();
            DataAssistant.IsRecording = true;

            DataAssistant.Listener.StartRecording();
            
        }
        public static void Stop() {
            DataAssistant.Listener.StopRecording();
            DataAssistant.IsRecording = false;
        }

        public static void Listener_DataAvailable(object sender, WaveInEventArgs e){
            DataAssistant.Writer.WriteData(e.Buffer, 0, e.BytesRecorded);
        }
        public static void Listener_RecordingStopped(object sender, EventArgs e) {
            DataAssistant.Listener.Dispose();
            DataAssistant.Listener = null;
            DataAssistant.Writer.Close();
            DataAssistant.Writer = null;
            ControlRecognition.StartTranslate();
        }
    }
}
