using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HoraAssistant{
    public static class DataAssistant{
        public static string NameFileWriter = @"sound.wav";
        public static string FolderNameFile="Sounds/";
        public static int CountSound = 0;
        public static bool IsRecording = false;
        public static WaveIn Listener = null;
        public static WaveFileWriter Writer=null;
        
        public static void SetValuesListener() {
            if (Listener == null){
                Listener = new WaveIn(){
                    DeviceNumber = 0,
                    WaveFormat = new WaveFormat(16000, 1)
                };
                Listener.RecordingStopped += new EventHandler<NAudio.Wave.StoppedEventArgs>(RecordingSound.Listener_RecordingStopped);
                Listener.DataAvailable += RecordingSound.Listener_DataAvailable;
            }
        }
        public static void SetValuesWriter() {
            if (Listener == null)
                SetValuesListener();
            if (Writer == null)
                Writer = new WaveFileWriter(FolderNameFile+CountSound++.ToString()+NameFileWriter,Listener.WaveFormat);
        }
    }
}
