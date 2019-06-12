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
        public string PathURL = "";
        public string Start(){
            string answer = "Невиконано";
            try{
                System.Diagnostics.Process.Start(PathURL);
                answer= "Виконано";
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
            parameters.InnerText = PathURL;
            task.AppendChild(parameters);

            return task;
        }

        public string GetValueTask(){
            return PathURL;
        }
    }
}
