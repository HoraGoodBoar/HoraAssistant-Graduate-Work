using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Xml;

namespace HoraAssistant{
    class CMD : ITaskFather{
        public string GetNameTask { get { return "Виключити/Деактивувати ПК"; } }
        public string ParameterCMD = "";

        public XmlElement SaveToXML(ref XmlDocument xDoc){
            XmlElement task = xDoc.CreateElement("task");

            XmlAttribute NameAtribute = xDoc.CreateAttribute("Name");
            NameAtribute.AppendChild(xDoc.CreateTextNode(GetNameTask));

            task.Attributes.Append(NameAtribute);

            XmlElement parameters = xDoc.CreateElement("ParameterCMD");
            parameters.InnerText = ParameterCMD;

            task.AppendChild(parameters);

            return task;
        }
        public string Start(){
            string answer = "Невиконано";
            try{
                System.Diagnostics.Process.Start(CMDControl.Command,(ParameterCMD=="/a"? ParameterCMD:" /s /t "+ParameterCMD));
                answer = "Виконано";
            }
            catch(Exception s) { MessageBox.Show(s.Message); }
            return answer;
        }

        public string GetValueTask(){
            return ParameterCMD;
        }
    }
}
