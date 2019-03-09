using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace HoraAssistant{
    public static class DataRecognition{
        public static WebRequest Request=null;
        public static string RequestPath = "https://www.google.com/speech-api/v2/recognize?output=json&lang=ru-RU&key=AIzaSyBOti4mM-6x9WDnZIjIeyEU21OpBXqWBgw";
        public static int CountRequest = 0;
        public static int MinByteFromTranslate = 10;
        public static List<string> ParserData(string Reader) {
            List<string> words = new List<string>();
            for (int i = 2; i < Reader.Length; ++i){
                if (Reader[i - 1] == ':' && Reader[i] == '"'){
                    string word = "";
                    for (int j = i + 1; j < Reader.Length; ++j){
                        if (Reader[j] != '"')
                            word += Reader[j];
                        else{
                            i = j;
                            words.Add(word);
                            break;
                        }
                    }
                }
            }
            if (words.Count == 0)
                words.Add("#?#");
            return words;
        }

        public static void SetValueRequest(string NameFile) {
            Request = WebRequest.Create(RequestPath);
            Request.Method = "POST";
            FileRecognition.LoadFileToRequest(NameFile,ref Request);
        }
    }
}
