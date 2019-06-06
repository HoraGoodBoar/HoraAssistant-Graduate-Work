using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Windows;
using System.Xml;

namespace HoraAssistant
{
    class Notification : ITaskFather
    {
        public string GetNameTask { get { return "Нагадати"; } }
        public string Text = "Немає";
        public int Day = 0;
        public int Hour = 0;
        public int Minute = 0;
        public bool IsTalk = false;

        public string GetValueTask()
        {
            return Text;
        }

        public XmlElement SaveToXML(ref XmlDocument xDoc)
        {
            XmlElement task = xDoc.CreateElement("task");

            XmlAttribute NameAtribute = xDoc.CreateAttribute("Name");
            NameAtribute.AppendChild(xDoc.CreateTextNode(GetNameTask));

            task.Attributes.Append(NameAtribute);

            XmlElement parameters0 = xDoc.CreateElement("Day");
            parameters0.InnerText = Day.ToString();
            XmlElement parameters1 = xDoc.CreateElement("Hour");
            parameters1.InnerText = Hour.ToString();
            XmlElement parameters2 = xDoc.CreateElement("Minute");
            parameters2.InnerText = Minute.ToString();
            XmlElement parameters3 = xDoc.CreateElement("Text");
            parameters3.InnerText = Text;

            task.AppendChild(parameters0);
            task.AppendChild(parameters1);
            task.AppendChild(parameters2);
            task.AppendChild(parameters3);

            return task;
        }

        public string Start()
        {
            string answer = "False";
            try
            {
                SpeechSynthesizer ss = new SpeechSynthesizer();
                ss.SelectVoice(ss.GetInstalledVoices(new CultureInfo("ru-RU"))[0].VoiceInfo.Name);
                ss.Volume = TalkData.Volume;
                ss.Rate = TalkData.Rate;
                ss.SpeakAsync(Text);
                answer = "True";
            }
            catch (Exception s) { MessageBox.Show(s.Message); }
            return answer;
        }
    }
}
