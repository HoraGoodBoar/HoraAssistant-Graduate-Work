using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Xml;

namespace HoraAssistant{
    interface ITaskFather{
        string Start();
        string GetNameTask{ get; }
        XmlElement SaveToXML(ref XmlDocument xDoc);
    }
}
