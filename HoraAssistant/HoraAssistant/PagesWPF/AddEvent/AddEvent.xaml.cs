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
    public partial class AddEvent : Page{
        public AddEvent(){
            InitializeComponent();
            Start();
        }
        public void Start() {
            ComboBoxNameEvents.ItemsSource = EventData.NameEvents;
        }

        private void BtnAddClick(object sender, RoutedEventArgs e){

        }

        private void BtnAddTaskClick(object sender, RoutedEventArgs e){
            StackPanelTask.Children.Add(new CheckBox() { Content = ComboBoxNameEvents.SelectedValue, Height = 40});
        }

        private void BtnDeleteTaskClick(object sender, RoutedEventArgs e){
            for (int i = 0; i < StackPanelTask.Children.Count; ++i)
                if ((bool)(StackPanelTask.Children[i] as CheckBox).IsChecked){
                    StackPanelTask.Children.RemoveAt(i);
                    i = i - 1 > 0 ? i-1 : -1;
                }
        }

        private void ComboBoxNameEventsSelectionChanged(object sender, SelectionChangedEventArgs e){

        }
    }
}
