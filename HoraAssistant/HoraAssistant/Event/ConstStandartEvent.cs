using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HoraAssistant{
    static class ConstStandartEvent{
        public static bool HaveOrNo(string word) {

            if (word.Contains("Найти") || word.Contains("найти")){
                System.Diagnostics.Process.Start("https://google.com/search?q=" + word.Remove(0, 5));
                PageMainData.Words.Add(word + " | " + " true");
                return true;
            }
            return false;
        }
    }
}
