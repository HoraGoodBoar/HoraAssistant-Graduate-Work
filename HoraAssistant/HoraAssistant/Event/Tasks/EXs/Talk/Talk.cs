using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Speech;
using System.Speech.Synthesis;
using System.Globalization;

namespace HoraAssistant{
    public class Talk : ITaskFather{
        public string GetNameTask { get { return "Говорити"; } }
        public string Word = "";
        public string GetValueTask(){
            return Word;
        }

        public string Start(){
            string answer = "False";
            try{
                SpeechSynthesizer ss = new SpeechSynthesizer();
                ss.SelectVoice(ss.GetInstalledVoices(new CultureInfo("ru-RU"))[0].VoiceInfo.Name);
                ss.Volume = TalkData.Volume;
                ss.Rate = TalkData.Rate;
                ss.SpeakAsync(Word);
                answer = "True";
            }
            catch (Exception s){ System.Windows.Forms.MessageBox.Show(s.Message); }
            return answer;
        }
        public XmlElement SaveToXML(ref XmlDocument xDoc){
            XmlElement task = xDoc.CreateElement("task");

            XmlAttribute NameAtribute = xDoc.CreateAttribute("Name");
            NameAtribute.AppendChild(xDoc.CreateTextNode(GetNameTask));

            task.Attributes.Append(NameAtribute);

            XmlElement parameters = xDoc.CreateElement("Word");
            parameters.InnerText = Word;
            task.AppendChild(parameters);

            return task;
        }
    }
}
