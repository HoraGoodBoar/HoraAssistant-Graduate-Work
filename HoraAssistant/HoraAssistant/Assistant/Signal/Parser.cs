using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using NAudio.CoreAudioApi;

namespace HoraAssistant{
    public static class Parser{
        public static void Start(){
            TimerStart();
        }
        public static void Stop() {
            TimerStop();
        }
        public static void TimerStart(){
            DataSignal.timer.Tick += Tim_Tick;
            DataSignal.timer.Start();
        }
        public static void TimerStop(){
            DataSignal.timer.Stop();
        }
        private static void Tim_Tick(object sender, EventArgs e){
            if(DataAssistant.IsWork)
                if (DataSignal.ChoiceDeviceIndex!=-1){
                    if ((int)(Math.Round(DataSignal.Devices[DataSignal.ChoiceDeviceIndex].AudioMeterInformation.MasterPeakValue * 100)) >= DataSignal.LevelDevice)
                    {
                        ControlRecording.StartRecording();
                    }
                    else
                    {
                        ControlRecording.StopRecording();
                    }
                }
        }
    }
}
