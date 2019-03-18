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
    public partial class Setup : Page{
        public Setup(){
            InitializeComponent();
            Start();
        }
        public void Start() {
            for(int i=0;i<DataSignal.Devices.Count;++i)
                ChoiceMicrophone.Items.Add(DataSignal.Devices[i].FriendlyName);
            ChoiceMicrophone.SelectedIndex = DataSignal.ChoiceDeviceIndex;
            SliderValue.Value = DataSignal.LevelDevice;
            WorkCheckBox.IsChecked = DataAssistant.IsWork;
            WorkCheckBox.Checked += WorkCheckBoxChecked;
            WorkCheckBox.Unchecked += WorkCheckBoxChecked;
        }

        private void ChoiceMicrophoneSelectionChanged(object sender, SelectionChangedEventArgs e){
            DataSignal.ChoiceDeviceIndex = ChoiceMicrophone.SelectedIndex;
        }

        private void SliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e){
            DataSignal.LevelDevice = Convert.ToInt32(SliderValue.Value);
            LblSliderValue.Content = DataSignal.LevelDevice.ToString();
        }

        private void WorkCheckBoxChecked(object sender, RoutedEventArgs e){
            DataAssistant.IsWork = (bool)WorkCheckBox.IsChecked;
            if (!DataAssistant.IsWork)
                ControlRecording.StopRecording();
        }
    }
}
