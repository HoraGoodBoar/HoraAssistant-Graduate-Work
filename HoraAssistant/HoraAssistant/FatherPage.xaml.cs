using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HoraAssistant{
    public partial class FatherPage : Window{
        public FatherPage(){
            InitializeComponent();
            ControlSignal.Start();
        }

        private void ClosingAssistant(object sender, System.ComponentModel.CancelEventArgs e){
            ControlSignal.Stop();
        }

        private void MenuClickItem (object sender, RoutedEventArgs e){
            switch ((sender as MenuItem).Header) {
                case "Головна": { PanelPages.Content = new Main(); }break;
            }
        }
    }
}
