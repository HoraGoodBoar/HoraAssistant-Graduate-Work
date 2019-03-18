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
            EventControl.LoadData();
            ControlSignal.Start();
            TaskBarControl.StartTaskBar();
            PanelPages.Content = new Main();
        }

        private void ClosingAssistant(object sender, System.ComponentModel.CancelEventArgs e){
            if (!TaskBarData.taskbar.Visible){
                e.Cancel = true;
                TaskBarData.taskbar.Visible = true;
                this.Visibility = Visibility.Hidden;
            }
            else{
                ControlSignal.Stop();
                ControlThreads.Clear();
            }
        }

        private void MenuClickItem (object sender, RoutedEventArgs e){
            switch ((sender as MenuItem).Header) {
                case "Головна": { PanelPages.Content = new Main(); }break;
                case "Додати дію": { PanelPages.Content = new AddEvent(); } break;
                case "Дії": { PanelPages.Content = new AllEvents(); } break;
                case "Налаштування": { PanelPages.Content = new Setup(); } break;
                case "Допомога": { PanelPages.Content = new Help(); } break;
            }
        }
    }
}
