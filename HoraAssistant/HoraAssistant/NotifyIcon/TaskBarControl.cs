using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HoraAssistant{
    public static class TaskBarControl{
        public static void StartTaskBar() {
            TaskBarData.menustrip.Items.Add("Виключити");
            TaskBarData.taskbar.ContextMenuStrip = TaskBarData.menustrip;
            TaskBarData.menustrip.ItemClicked += MenustripItemClicked;
            TaskBarData.taskbar.Visible = false;
            TaskBarData.taskbar.DoubleClick += TaskbarDoubleClick;
        }


        private static void TaskbarDoubleClick(object sender, EventArgs e){
            App.Current.Windows[0].Visibility = System.Windows.Visibility.Visible;
            TaskBarData.taskbar.Visible = false;
        }

        private static void MenustripItemClicked(object sender, System.Windows.Forms.ToolStripItemClickedEventArgs e){
            if (e.ClickedItem.Text == "Виключити") {
                App.Current.Windows[0].Close();
            }
        }
    }
}
