using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using System.Xml;

namespace HoraAssistant{
    public class OpenURLChrome : ITaskFather {
        public string PathMusic = "";
        public string Start(){
            string answer = "False";
            try{
                System.Diagnostics.Process.Start(PathMusic);
                answer= "True";
            }
            catch {}
            return answer;
        }
        public string GetNameTask {
            get { return "Відкрити в Chrome"; }
        }
        public XmlElement SaveToXML(ref XmlDocument xDoc){
            XmlElement task = xDoc.CreateElement("task");

            XmlAttribute NameAtribute = xDoc.CreateAttribute("Name");
            NameAtribute.AppendChild(xDoc.CreateTextNode(GetNameTask));

            task.Attributes.Append(NameAtribute);

            XmlElement parameters = xDoc.CreateElement("PathURL");
            parameters.InnerText = PathMusic;

            task.AppendChild(parameters);

            return task;
        }
    }
}
