using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xml;

namespace HoraAssistant{
    public static class OpenFileControl{
        public static System.Windows.Forms.OpenFileDialog Explorer = new System.Windows.Forms.OpenFileDialog();

        public static string ChoiceFile() {
            string answer = "";
            if (Explorer.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                return Explorer.FileName;
            }
            return answer;
        }
        public static bool FileExists(string PathFile) {
            return File.Exists(PathFile);
        }

        public static void GetGrid(ref Grid menu){
            menu.Children.Clear();
            menu.Background = Brushes.DarkGreen;
            TextBox Txtpath = new TextBox() { };
            Button BtnPath = new Button() { Content="Вибрати файл",Foreground=Brushes.White};
            BtnPath.Click += BtnPathClick;
            StackPanel panel = new StackPanel();
            panel.Children.Add(BtnPath);
            panel.Children.Add(Txtpath);
            menu.Children.Add(panel);
        }

        private static void BtnPathClick(object sender, System.Windows.RoutedEventArgs e){
            ((((App.Current.Windows[0] as FatherPage).PanelPages.Content as AddEvent).GridInfoEvent.Children[0] as StackPanel).Children[1] as TextBox).Text  = ChoiceFile();
        }

        public static object LoadParameters(ref Grid menu)
        {
            return new OpenFile() { PathFile = ((menu.Children[0] as StackPanel).Children[1] as TextBox).Text };
        }
        public static void LoadOpenURLChromeForXML(ref EventModel Event, XmlNode node){
            OpenFile task = new OpenFile();
            task.PathFile = node.ChildNodes[0].InnerText.ToString();
            Event.Tasks.Add(task);
        }
    }
}
