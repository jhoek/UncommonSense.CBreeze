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
    public partial class TimeTableField : TableField
    {
        private TimeTableFieldProperties properties = new TimeTableFieldProperties();

        public TimeTableField(int no, string name) : base(no, name)
        {
        }

        public override TableFieldType Type
        {
            get
            {
                return TableFieldType.Time;
            }
        }

        public TimeTableFieldProperties Properties
        {
            get
            {
                return this.properties;
            }
        }


        public override Properties AllProperties
        {
            get
            {
                return Properties;
            }
        }
    }
}
