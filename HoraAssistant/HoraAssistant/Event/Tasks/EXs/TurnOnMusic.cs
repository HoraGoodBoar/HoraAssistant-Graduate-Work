using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace HoraAssistant{
    public class TurnOnMusic : ITaskFather {
        public string PathMusic = "";

        public void GetGrid(ref Grid menu){
            menu.Children.Clear();
            menu.Background = Brushes.DarkGreen;
            
            TextBox Txtpath = new TextBox();
            Label LblName = new Label() { Content = "Яку силку відкрити : ", Foreground = Brushes.White };

            StackPanel panel = new StackPanel();
            panel.Children.Add(LblName);
            panel.Children.Add(Txtpath);

            menu.Children.Add(panel);
        }

        public object LoadParameters(ref Grid menu){
            return new TurnOnMusic() { PathMusic = ((menu.Children[0] as StackPanel).Children[1] as TextBox).Text };
        }

        public string Start(){
            string answer = "False";
            try{
                System.Diagnostics.Process.Start(PathMusic);
                answer= "True";
            }
            catch {}
            return answer;
        }
    }
}
