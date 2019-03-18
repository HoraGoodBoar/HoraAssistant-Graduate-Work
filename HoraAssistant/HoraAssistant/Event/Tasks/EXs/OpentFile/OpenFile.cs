using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Diagnostics;

namespace HoraAssistant{
    public class OpenFile : ITaskFather{
        public string PathFile="";
        public string GetNameTask { get { return "Відкрити файл"; } }

        public string GetValueTask(){
            return PathFile;
        }

        public XmlElement SaveToXML(ref XmlDocument xDoc){
            XmlElement task = xDoc.CreateElement("task");

            XmlAttribute NameAtribute = xDoc.CreateAttribute("Name");
            NameAtribute.AppendChild(xDoc.CreateTextNode(GetNameTask));

            task.Attributes.Append(NameAtribute);

            XmlElement parameters = xDoc.CreateElement("PathFile");
            parameters.InnerText = PathFile;

            task.AppendChild(parameters);

            return task;
        }

        public string Start(){
            string answer = "False";
            if(OpenFileControl.FileExists(PathFile)){
                try{
                    Process.Start(PathFile);
                    return "True";
                }
                catch (Exception s) {
                    MessageBox.Show(s.Message);
                }
            }
            return answer;
        }
    }
}
