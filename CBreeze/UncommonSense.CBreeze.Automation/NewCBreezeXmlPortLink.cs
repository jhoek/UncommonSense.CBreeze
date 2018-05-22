﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Core.Property.Implementation;
using UncommonSense.CBreeze.Core.XmlPort;
using UncommonSense.CBreeze.Write;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.New, "CBreezeXmlPortLink", DefaultParameterSetName = ParameterSetNames.NewWithoutID)]
    [Alias("XmlPortLink", "Add-CBreezeXmlPortLink")]
    [OutputType(typeof(LinkField))]
    public class NewCBreezeXmlPortLink : NewItemCmdlet<LinkField, PSObject>
    {
        protected override void AddItemToInputObject(LinkField item, PSObject inputObject)
        {
            switch (inputObject.BaseObject)
            {
                case LinkFields l:
                    l.Add(item);
                    break;

                case XmlPortTableElement e:
                    e.Properties.LinkFields.Add(item);
                    break;

                case XmlPortTableAttribute a:
                    a.Properties.LinkFields.Add(item);
                    break;

                default:
                    base.AddItemToInputObject(item, inputObject);
                    break;
            }
        }

        protected override IEnumerable<LinkField> CreateItems()
        {
            yield return new LinkField(Field, ReferenceField);
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