using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading;
using System.IO;
using System.Windows;

namespace HoraAssistant{
    public static class XMLControl{
        public static void LoadFileEvents() {
            Thread loading = new Thread(new ThreadStart(()=> {
                try{
                    XMLData.document.Load(XMLData.PathFile);
                    XmlElement root = XMLData.document.DocumentElement;
                    for (int i = 0; i < root.ChildNodes.Count; ++i){
                        EventModel Event = new EventModel();
                        Event.Name = root.ChildNodes[i].Attributes["Name"].Value.ToString();
                        Event.Description = root.ChildNodes[i].Attributes["Description"].Value.ToString();
                        for (int j = 0; j < root.ChildNodes[i].ChildNodes.Count; ++j){
                            switch (root.ChildNodes[i].ChildNodes[j].Attributes["Name"].Value.ToString()){
                                case "Відкрити в Chrome": { OpenURLChromeControl.LoadOpenURLChromeForXML(ref Event, root.ChildNodes[i].ChildNodes[j]); } break;
                                case "Виключити/Деактивувати ПК": {CMDControl.LoadOpenURLChromeForXML(ref Event, root.ChildNodes[i].ChildNodes[j]); } break;
                                case "Відкрити файл": { OpenFileControl.LoadOpenURLChromeForXML(ref Event, root.ChildNodes[i].ChildNodes[j]); } break;
                                case "Говорити": { TalkControl.LoadOpenURLChromeForXML(ref Event, root.ChildNodes[i].ChildNodes[j]); } break;
                            }
                        }
                        EventData.Events.Add(Event);
                    }
                }
                catch(Exception s) { MessageBox.Show(s.Message); }
            }));
            if (ControlThreads.ContaintName("XMLLoad"))
                ControlThreads.RemoveKey("XMLLoad");
            ControlThreads.AddThread("XMLLoad",loading);
            loading.Start();
        }
        public static void SaveToFileEvent(EventModel Event) {
            XmlElement newEvent = XMLData.document.CreateElement("event");

            XmlAttribute NameAtribute = XMLData.document.CreateAttribute("Name");
            NameAtribute.AppendChild(XMLData.document.CreateTextNode(Event.Name));
            XmlAttribute DescriptionAtribute = XMLData.document.CreateAttribute("Description");
            NameAtribute.AppendChild(XMLData.document.CreateTextNode(Event.Description));

            newEvent.Attributes.Append(NameAtribute);
            newEvent.Attributes.Append(DescriptionAtribute);

            for (int i = 0; i < Event.Tasks.Count; ++i)
                newEvent.AppendChild((Event.Tasks[i] as ITaskFather).SaveToXML(ref XMLData.document));

            XMLData.document.DocumentElement.AppendChild(newEvent);
            XMLData.document.Save(XMLData.PathFile);
        }
        public static void DeleteEvent(string Name) {
            XmlElement root = XMLData.document.DocumentElement;
            for (int i = 0; i < root.ChildNodes.Count; ++i)
                if (root.ChildNodes[i].Attributes["Name"].Value == Name)
                    root.RemoveChild(root.ChildNodes[i--]);
            XMLData.document.Save(XMLData.PathFile);
            EventData.Events.Clear();
            LoadFileEvents();
        }
    }
}
