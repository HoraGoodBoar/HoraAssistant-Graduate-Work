using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xml;

namespace HoraAssistant{
    public static class CMDControl{
        public static string Command = "shutdown";
        public static string ExeName = "cmd.exe";
        public static void GetGrid(ref Grid menu){
            menu.Children.Clear();
            menu.Background = Brushes.DarkGreen;
            TextBox Txtpath = new TextBox();
            Label LblNameOne = new Label() { Content = "Деаяктивуват (-а)", Foreground = Brushes.White };
            Label LblNameTwo = new Label() { Content = "Виключити (1000=1сек.) : ", Foreground = Brushes.White };

            StackPanel panel = new StackPanel();
            panel.Children.Add(LblNameOne);
            panel.Children.Add(LblNameTwo);
            panel.Children.Add(Txtpath);
            menu.Children.Add(panel);
        }
        public static object LoadParameters(ref Grid menu){
            return new CMD() { ParameterCMD = ((menu.Children[0] as StackPanel).Children[2] as TextBox).Text };
        }
        public static void LoadOpenURLChromeForXML(ref EventModel Event, XmlNode node){
            CMD task = new CMD();
            task.ParameterCMD = node.ChildNodes[0].InnerText.ToString();
            Event.Tasks.Add(task);
        }
    }
}
