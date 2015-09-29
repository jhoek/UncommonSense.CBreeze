using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Utils;

namespace UncommonSense.CBreeze.Automation
{
    public abstract class AddCBreezePageControl : Cmdlet
    {
        [Parameter(Mandatory=true, ValueFromPipeline=true)]
        public Page Page
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

        [Parameter(ParameterSetName = "ID")]
        [ValidateRange(1, int.MaxValue)]
        public int ID
        {
            get;
            set;
        }

        [Parameter]
        public SwitchParameter PassThru
        {
            get;
            set;
        }

        protected int GetPageControlID()
        {
            if (ID != 0)
                return ID;

            var range = Range;

            if (Range.Contains(Page.ID))
                range = 1.To(int.MaxValue);

            return range.Except(Page.Controls.Select(c => c.ID)).First();
        }
    }
}
