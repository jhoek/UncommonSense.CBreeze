using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Utils;

namespace UncommonSense.CBreeze.Automation
{
    public abstract class AddCBreezeTableField : Cmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public Table[] Table
        {
            get;
            set;
        }

        [Parameter(ParameterSetName = "Range")]
        public IEnumerable<int> Range
        {
            get;
            set;
        }

        [Parameter(ParameterSetName = "No")]
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

        [Parameter()]
        public SwitchParameter PassThru
        {
            get;
            set;
        }

        [Parameter()]
        public SwitchParameter PrimaryKeyFieldNoRange
        {
            get;
            set;
        }

        protected int GetNo()
        {
            if (No != 0)
                return No;

            var range = Range;

            if (Range.Contains(Table.ID))
            {
                switch (PrimaryKeyFieldNoRange.IsPresent)
                {
                    case true:
                        range = 1.To(int.MaxValue);
                        break;
                    case false:
                        range = 10.To(int.MaxValue);
                        break;
                }
            }

            return range.Except(Table.Fields.Select(f => f.ID)).First();
        }
    }
}
