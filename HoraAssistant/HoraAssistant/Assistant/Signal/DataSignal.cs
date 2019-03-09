using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NAudio.CoreAudioApi;

namespace HoraAssistant{
    public static class DataSignal {
        public static int ChoiceDeviceIndex = 1;
        public static int LevelDevice = 1;
        public static int IntervalFromTimer = 100;
        public static MMDeviceCollection Devices = new MMDeviceEnumerator().EnumerateAudioEndPoints(DataFlow.All, DeviceState.Active);
        public static System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer() { Interval = IntervalFromTimer };
    }
}
