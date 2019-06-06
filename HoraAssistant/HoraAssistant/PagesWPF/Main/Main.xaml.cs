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
            for (int i = 0; i < EventData.Events.Count; ++i) {
                for (int j = 0; j < EventData.Events[i].Tasks.Count; ++j)
                {
                    if ((EventData.Events[i].Tasks[j] is Notification))
                    {
                        if ((EventData.Events[i].Tasks[j] as Notification).IsTalk == false)
                        {
                            if ( (EventData.Events[i].Tasks[j] as Notification).Day >= DateTime.Now.Day   &&
                                 (EventData.Events[i].Tasks[j] as Notification).Hour == DateTime.Now.Hour &&
                                 (EventData.Events[i].Tasks[j] as Notification).Minute == DateTime.Now.Minute 
                               )
                            {
                                (EventData.Events[i].Tasks[j] as Notification).Start();
                                (EventData.Events[i].Tasks[j] as Notification).IsTalk = true;
                            }
                        }
                    }
                }
            }
        }
    }
}
