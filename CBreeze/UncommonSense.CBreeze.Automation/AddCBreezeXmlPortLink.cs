using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Write;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeXmlPortLink")]
    public class AddCBreezeXmlPortLink : Cmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public XmlPortNode InputObject
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, Position = 0)]
        [ValidateRange(1, int.MaxValue)]
        public int Field
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, Position = 1)]
        [ValidateRange(1, int.MaxValue)]
        public int ReferenceField
        {
            get;
            set;
        }

        protected override void ProcessRecord()
        {
            TypeSwitch.Do(
                InputObject,
                TypeSwitch.Case<LinkFields>(i => i.Add(new LinkField(Field, ReferenceField))),
                TypeSwitch.Case<XmlPortTableElement>(i => i.Properties.LinkFields.Add(new LinkField(Field, ReferenceField))),
                TypeSwitch.Case<XmlPortTableAttribute>(i => i.Properties.LinkFields.Add(new LinkField(Field, ReferenceField))),
                TypeSwitch.Default(() => InvalidInputObject())
                );
        }

        protected void InvalidInputObject()
        {
            throw new ArgumentOutOfRangeException("Don't know how to add XMLport links to this input object.");
        }
    }
}
