﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace HoraAssistant{
    public static class ControlRecognition{
        public static List<string> Start(string NameFile) {
            return SendRequest.Send(NameFile);
        }
        public static void StartTranslate() {
            string word = Start(DataAssistant.FolderNameFile+ (DataAssistant.CountSound - 1).ToString() + DataAssistant.NameFileWriter)[0];
            if(word!="#?#")
                App.Current.Dispatcher.Invoke(new Action(() => {
                    App.Current.Windows[0].Title += word;
                }));
        }
    }
}