using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
            SliderValueAssistant.Value = TalkData.Volume;
            SliderValueRate.Value = TalkData.Rate;
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

        private void SliderValueAssistantValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e){
            TalkData.Volume = Convert.ToInt32(SliderValueAssistant.Value);
            LblValueAssistant.Content = TalkData.Volume.ToString();
        }

        private void SliderValueRateValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e){
            TalkData.Rate = Convert.ToInt32(SliderValueRate.Value);
            LblValueRate.Content = TalkData.Rate.ToString();
        }
    }
}
