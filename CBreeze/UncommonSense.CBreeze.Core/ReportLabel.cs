// --------------------------------------------------------------------------------
// <auto-generated>
//      This code was generated by a tool.
//
//      Changes to this file may cause incorrect behaviour and will be lost if
//      the code is regenerated.
// </auto-generated>
// --------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class ReportLabel : KeyedItem<int>, IHasName
    {
        public ReportLabel(int id, string name)
        {
            ID = id;
            Name = name;
            Properties = new ReportLabelProperties();
        }

        public string Name
        {
            get;
            protected set;
        }

        public ReportLabelProperties Properties
        {
            get;
            protected set;
        }

        public string GetName()
        {
            return Name;
        }
    }
}
