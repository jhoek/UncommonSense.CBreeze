using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class ReportDataItemLinkProperty : Property
    {
        private ReportDataItemLink value = new ReportDataItemLink();

        internal ReportDataItemLinkProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.Any();
            }
        }

        public ReportDataItemLink Value
        {
            get
            {
                return this.value;
            }
        }
    }

}
