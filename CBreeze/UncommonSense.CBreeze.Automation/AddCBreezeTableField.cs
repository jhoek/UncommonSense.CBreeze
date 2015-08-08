using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    public abstract class AddCBreezeTableField : AddCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public Table Table
        {
            get;
            set;
        }

        [Parameter()]
        [ValidateRange(1, int.MaxValue)]
        public int No
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, Position = 0)]
        public string Name
        {
            get;
            set;
        }

        [Parameter()]
        public SwitchParameter AutoCaption
        {
            get;
            set;
        }

        protected int AutoAssignNo(int no)
        {
            if (no != 0)
                return no;

            if (!Table.Fields.Any())
                return 1;

            return Table.Fields.Max(f => f.No) + 1;
        }
    }
}
