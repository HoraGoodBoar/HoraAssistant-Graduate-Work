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
                XMLData.document.Load(XMLData.PathFile);
                XmlElement root = XMLData.document.DocumentElement;
                for (int i = 0; i < root.ChildNodes.Count; ++i){
                    EventModel Event = new EventModel();
                    Event.Name = root.ChildNodes[i].Attributes["Name"].Value.ToString();
                    Event.Description = root.ChildNodes[i].Attributes["Description"].Value.ToString();
                    for (int j = 0; j < root.ChildNodes[i].ChildNodes.Count; ++j)
                    {
                        switch (root.ChildNodes[i].ChildNodes[j].Attributes["Name"].Value.ToString())
                        {
                            case "Відкрити в Chrome": { XMLTurnOnMusic(ref Event, root.ChildNodes[i].ChildNodes[j]); } break;
                        }
                    }
                    EventData.Events.Add(Event);
                }
            }));
            ControlThreads.AddThread("XMLLoad",loading);
            loading.Start();
        }

        public static void XMLTurnOnMusic(ref EventModel Event,XmlNode node) {
            TurnOnMusic task = new TurnOnMusic();
            task.PathMusic = node.ChildNodes[0].InnerText.ToString();
            MessageBox.Show(task.PathMusic);
            Event.Tasks.Add(task);
        }
    }
}
