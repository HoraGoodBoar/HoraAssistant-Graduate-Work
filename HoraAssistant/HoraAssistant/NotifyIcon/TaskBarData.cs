using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HoraAssistant{
    public static class TaskBarData{
        public static NotifyIcon taskbar = new NotifyIcon() { Icon= new System.Drawing.Icon("H.ico") };
        public static ContextMenuStrip menustrip = new ContextMenuStrip();
    }
}
