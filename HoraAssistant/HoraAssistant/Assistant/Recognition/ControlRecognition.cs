using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Controls;

namespace HoraAssistant{
    public static class ControlRecognition{
        public static List<string> Start(string NameFile) {
            return SendRequest.Send(NameFile);
        }
        public static void StartTranslate() {
            string word = Start(DataAssistant.FolderNameFile+ (DataAssistant.CountSound - 1).ToString() + DataAssistant.NameFileWriter)[0];

            if (ConstStandartEvent.HaveOrNo(word) == false  && word != "#?#" && word != " "){
                string log = "";
                if(EventData.Contains(word)){
                    List<string> answers = EventControl.StartEvent(word);
                    for (int i = 0; i < answers.Count; ++i)
                        log += i.ToString() + " : " + answers[i] + "; ";
                    PageMainData.Words.Add(word + " | " + (log == "" ? "немає завдань" : log));
                }
                else
                    PageMainData.Words.Add(word + " | " + "нерозпізнано" );
            }
        }
    }
}
