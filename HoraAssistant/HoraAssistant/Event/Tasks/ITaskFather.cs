using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace HoraAssistant{
    interface ITaskFather{
        string Start();
        object LoadParameters(ref Grid menu);
        void GetGrid(ref Grid menu);
    }
}
