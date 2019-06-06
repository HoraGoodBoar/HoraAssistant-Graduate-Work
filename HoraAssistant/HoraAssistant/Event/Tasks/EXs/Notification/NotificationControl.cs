using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xml;

namespace HoraAssistant{
    class NotificationControl{
        public static void GetGrid(ref Grid menu)
        {
            menu.Children.Clear();
            menu.Background = Brushes.DarkGreen;
            TextBox TxtOne = new TextBox();
            Label LblNameOne = new Label() { Content = "Текст : ", Foreground = Brushes.White };
            TextBox TxtTwo = new TextBox();
            Label LblNameTwo = new Label() { Content = "День : ", Foreground = Brushes.White };
            TextBox TxtThree = new TextBox();
            Label LblNameThree = new Label() { Content = "Година : ", Foreground = Brushes.White };
            TextBox TxtFour = new TextBox();
            Label LblNameFour = new Label() { Content = "Хвилина : ", Foreground = Brushes.White };

            StackPanel panel = new StackPanel();
            panel.Children.Add(LblNameOne);
            panel.Children.Add(TxtOne);
            panel.Children.Add(LblNameTwo);
            panel.Children.Add(TxtTwo);
            panel.Children.Add(LblNameThree);
            panel.Children.Add(TxtThree);
            panel.Children.Add(LblNameFour);
            panel.Children.Add(TxtFour);

            menu.Children.Add(panel);
        }
        public static object LoadParameters(ref Grid menu)
        {
            return new Notification()
            {
                Text = ((menu.Children[0] as StackPanel).Children[1] as TextBox).Text,
                Day = Int32.Parse(((menu.Children[0] as StackPanel).Children[3] as TextBox).Text),
                Hour = Int32.Parse(((menu.Children[0] as StackPanel).Children[5] as TextBox).Text),
                Minute = Int32.Parse(((menu.Children[0] as StackPanel).Children[7] as TextBox).Text)
            };
        }
        public static void LoadOpenURLChromeForXML(ref EventModel Event, XmlNode node)
        {
            Notification task = new Notification();
           
            task.Day = Int32.Parse(node.ChildNodes[0].InnerText.ToString());
            task.Hour = Int32.Parse(node.ChildNodes[1].InnerText.ToString());
            task.Minute = Int32.Parse(node.ChildNodes[2].InnerText.ToString());
            task.Text = node.ChildNodes[3].InnerText.ToString();
            Event.Tasks.Add(task);
        }
    }
}
