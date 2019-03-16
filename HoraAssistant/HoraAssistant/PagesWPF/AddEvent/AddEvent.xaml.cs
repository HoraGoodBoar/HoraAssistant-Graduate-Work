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
            if (TextBoxName.Text != ""){
                PageAddEventData.AddStorage.Name = TextBoxName.Text;
                PageAddEventData.AddStorage.Description = TextBoxDescription.Text;
                EventData.Events.Add(PageAddEventData.AddStorage);
                XMLControl.SaveToFileEvent(PageAddEventData.AddStorage);
                TextBoxName.BorderBrush = null;
                StackPanelTask.Children.Clear();
            }
            else
                TextBoxName.BorderBrush = Brushes.Red;
        }
        private void BtnAddTaskClick(object sender, RoutedEventArgs e){
            StackPanelTask.Children.Add(new CheckBox() { Content = ComboBoxNameEvents.SelectedValue, Height = 40});
            if (ComboBoxNameEvents.SelectedItem != null){
                object task = null;
                switch (ComboBoxNameEvents.SelectedValue){
                    case "Відкрити в Chrome": { task= OpenURLChromeControl.LoadParameters(ref GridInfoEvent); } break;
                    case "Виключити/Деактивувати ПК": { task = CMDControl.LoadParameters(ref GridInfoEvent); } break;
                }
                if(task!=null)
                    PageAddEventData.AddStorage.Tasks.Add(task);
            }
        }
        private void BtnDeleteTaskClick(object sender, RoutedEventArgs e){
            for (int i = 0; i < StackPanelTask.Children.Count; ++i)
                if ((bool)(StackPanelTask.Children[i] as CheckBox).IsChecked){
                    StackPanelTask.Children.RemoveAt(i);
                    PageAddEventData.AddStorage.Tasks.RemoveAt(i);
                    i = i - 1 > 0 ? i-1 : -1;
                }
        }
        private void ComboBoxNameEventsSelectionChanged(object sender, SelectionChangedEventArgs e){
            if (ComboBoxNameEvents.SelectedItem != null) {
                switch (ComboBoxNameEvents.SelectedValue) {
                    case "Відкрити в Chrome": { OpenURLChromeControl.GetGrid(ref GridInfoEvent); } break;
                    case "Виключити/Деактивувати ПК": { CMDControl.GetGrid(ref GridInfoEvent); } break;
                }
            }
        }
    }
}
