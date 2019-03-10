using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace HoraAssistant{
    public static class PageMainData{
        public static System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer() { Interval = 1000 };
        public static DateTime StartWorkTime = DateTime.Now;
        public static ObservableCollection<string> Words = new ObservableCollection<string>();
    }
}
