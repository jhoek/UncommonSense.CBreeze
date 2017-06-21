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
    [Cmdlet(VerbsCommon.Add, "CBreezeXmlPortLink", DefaultParameterSetName = ParameterSetNames.NewWithoutID)]
    [Alias("Link")]
    [OutputType(typeof(LinkField))]
    public class NewCBreezeXmlPortLink : NewItemCmdlet<LinkField, PSObject>
    {
        protected override void AddItemToInputObject(LinkField item, PSObject inputObject)
        {
            TypeSwitch.Do(
                inputObject.BaseObject,
                TypeSwitch.Case<LinkFields>(i => i.Add(item)),
                TypeSwitch.Case<XmlPortTableElement>(i => i.Properties.LinkFields.Add(item)),
                TypeSwitch.Case<XmlPortTableAttribute>(i => i.Properties.LinkFields.Add(item)),
                TypeSwitch.Default(() => InvalidInputObject())
                );
        }

        protected override IEnumerable<LinkField> CreateItems()
        {
            yield return new LinkField(Field, ReferenceField);
        }

        protected void InvalidInputObject()
        {
            throw new ArgumentOutOfRangeException("Don't know how to add XMLport links to this input object.");
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
    }
}