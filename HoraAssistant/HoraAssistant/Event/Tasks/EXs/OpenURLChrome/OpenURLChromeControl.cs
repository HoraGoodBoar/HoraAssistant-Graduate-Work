using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xml;

namespace HoraAssistant{
    public static class OpenURLChromeControl{
        public static void GetGrid(ref Grid menu){
            menu.Children.Clear();
            menu.Background = Brushes.DarkGreen;
            TextBox Txtpath = new TextBox();
            Label LblName = new Label() { Content = "Яку силку відкрити : ", Foreground = Brushes.White };
            StackPanel panel = new StackPanel();
            panel.Children.Add(LblName);
            panel.Children.Add(Txtpath);
            menu.Children.Add(panel);
        }
        public static object LoadParameters(ref Grid menu){
            return new OpenURLChrome() { PathMusic = ((menu.Children[0] as StackPanel).Children[1] as TextBox).Text };
        }
        public static void LoadOpenURLChromeForXML(ref EventModel Event, XmlNode node) {
            OpenURLChrome task = new OpenURLChrome();
            task.PathMusic = node.ChildNodes[0].InnerText.ToString();
            Event.Tasks.Add(task);
        }
    }
}
