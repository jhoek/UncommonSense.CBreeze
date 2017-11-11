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
    [Cmdlet(VerbsCommon.New, "CBreezeRunObjectLink", DefaultParameterSetName = ParameterSetNames.NewWithoutID)]
    [Alias("RunObjectLink", "Add-CBreezeRunObjectLink")]
    [OutputType(typeof(RunObjectLinkLine))]
    public class NewCBreezeRunObjectLink : NewItemCmdlet<RunObjectLinkLine, PSObject>
    {
        protected override void AddItemToInputObject(RunObjectLinkLine item, PSObject inputObject)
        {
            switch (inputObject.BaseObject)
            {
                case PageAction a:
                    a.Properties.RunPageLink.Add(item);
                    break;

                case PartPageControl c:
                    c.Properties.SubPageLink.Add(item);
                    break;

                default:
                    base.AddItemToInputObject(item, inputObject);
                    break;
            }
        }

        protected override IEnumerable<RunObjectLinkLine> CreateItems()
        {
            yield return new RunObjectLinkLine(FieldName, Type, Value)
            {
                ValueIsFilter = ValueIsFilter,
                OnlyMaxLimit = OnlyMaxLimit
            };
        }

        [Parameter(Mandatory = true, Position = 1)] public string FieldName { get; set; }
        [Parameter()] public SwitchParameter OnlyMaxLimit { get; set; }
        [Parameter(Mandatory = true, Position = 2)] public TableFilterType Type { get; set; }
        [Parameter(Mandatory = true, Position = 3)] [AllowEmptyString()] public string Value { get; set; }
        [Parameter()] public SwitchParameter ValueIsFilter { get; set; }
    }
}