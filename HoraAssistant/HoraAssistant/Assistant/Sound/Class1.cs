using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HoraAssistant
{
   static class Class1
    {
        public static void StartClass1() {
            var waveIn = new WaveInEvent();
            waveIn.DataAvailable += WaveOnDataAvailable;
            waveIn.WaveFormat = new WaveFormat(500, 1);
            waveIn.DeviceNumber = 0;
            waveIn.StartRecording();

        }
        private static void WaveOnDataAvailable(object sender, WaveInEventArgs e)
        {

        }
    }
}
