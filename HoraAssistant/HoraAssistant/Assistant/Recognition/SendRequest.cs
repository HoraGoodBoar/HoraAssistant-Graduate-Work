using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace HoraAssistant { 
    public static class SendRequest{
        public static List<string> Send(string NameFile) {
            List<string> answer = new List<string>();
            DataRecognition.SetValueRequest(NameFile);
            if (DataRecognition.Request != null){
                HttpWebResponse response = (HttpWebResponse)DataRecognition.Request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                answer = DataRecognition.ParserData(reader.ReadToEnd());
                response.Close();
                reader.Close();
            }
            if (answer.Count == 0)
                answer.Add(" ");
            ++DataRecognition.CountRequest;
            return answer;
        }
    }
}
