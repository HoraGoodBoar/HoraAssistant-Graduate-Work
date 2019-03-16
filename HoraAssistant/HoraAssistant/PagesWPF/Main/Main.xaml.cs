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
    public partial class Main : Page {
        public Main() {
            InitializeComponent();
            StartTimer();
            HistoryWords.ItemsSource = PageMainData.Words;
        }
        public void StartTimer() {
            PageMainData.timer.Tick += TimerTickOne;
            PageMainData.timer.Start();
        }

        private void TimerTickOne(object sender, EventArgs e){
            TextBoxEvent.Text = EventData.CountTrue.ToString();
            TextBoxSound.Text = DataRecognition.CountRequest.ToString();
            TextBoxTime.Text  = DateTime.Parse((DateTime.Now - PageMainData.StartWorkTime).ToString()).ToLongTimeString();
        }
    }
}
