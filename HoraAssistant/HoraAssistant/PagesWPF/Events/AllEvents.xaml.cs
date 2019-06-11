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
    public partial class AllEvents : Page{
        public AllEvents(){
            InitializeComponent();
            Start();
        }
        public void Start() {
            for (int i = 0; i < EventData.Events.Count; ++i) {
                TreeViewItem FatherItem = new TreeViewItem() {
                    Header =EventData.Events[i].Name,
                    ToolTip = EventData.Events[i].Description,
                    Style= (Resources["MainStyle"] as Style)
                };
                FatherItem.MouseDoubleClick += FatherItemMouseDoubleClick;
                FatherItem.Expanded += FatherItem_Expanded;
                for (int j = 0; j < EventData.Events[i].Tasks.Count; ++j) {
                    TreeViewItem ChildrenItem = new TreeViewItem() {
                        Header =(EventData.Events[i].Tasks[j] as ITaskFather).GetNameTask,
                        ToolTip= (EventData.Events[i].Tasks[j] as ITaskFather).GetValueTask(),
                        Style = (Resources["MainStyle"] as Style)
                    };
                    ChildrenItem.Foreground = Brushes.Red;
                    FatherItem.Items.Add(ChildrenItem);
                }
                MainStackEvents.Children.Add(FatherItem);
            }
            if (EventData.Events.Count == 0) {
                InfoStackEvents.Children.Clear();
                InfoStackEvents.UpdateLayout();
            }
            MainStackEvents.UpdateLayout();
        }

        private void FatherItem_Expanded(object sender, RoutedEventArgs e){
            InfoStackEvents.Children.Clear();
            for (int i = 0; i < (sender as TreeViewItem).Items.Count; ++i){
                InfoStackEvents.Children.Add(new Label(){
                    Content = ((sender as TreeViewItem).Items[i] as TreeViewItem).Header.ToString(),
                    Style = (Resources["MainStyle"] as Style)
                });
                InfoStackEvents.Children.Add(new TextBox(){
                    Text = ((sender as TreeViewItem).Items[i] as TreeViewItem).ToolTip.ToString(),
                    Style = (Resources["MainStyle"] as Style),
                    Foreground = Brushes.Red
                });
            }
        }
        private void FatherItemMouseDoubleClick(object sender, MouseButtonEventArgs e){
            if (MessageBox.Show("Видаляться всі дії з таким словом", "Ви впевнені?", MessageBoxButton.YesNoCancel) == MessageBoxResult.Yes){
                XMLControl.DeleteEvent((sender as TreeViewItem).Header.ToString());
                EventControl.DeleteFromName((sender as TreeViewItem).Header.ToString());
                MainStackEvents.Children.Clear();
                InfoStackEvents.Children.Clear();
                InfoStackEvents.UpdateLayout();
                Start();
            }
        }
    }
}
