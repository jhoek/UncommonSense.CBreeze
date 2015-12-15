using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Write;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeLink")]
    public class AddCBreezeLink : Cmdlet
    {
        private const string ConstParameterSetName = "Const";
        private const string FilterParameterSetName = "Filter";
        private const string FieldParameterSetName = "Field";

        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public PSObject InputObject
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, Position = 0)]
        public string FieldName
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = ConstParameterSetName)]
        public SwitchParameter Const
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = FilterParameterSetName)]
        public SwitchParameter Filter
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = FieldParameterSetName)]
        public SwitchParameter Field
        {
            get;
            set;
        }

        [Parameter()]
        public string ReferenceDataItem
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, Position = 2)]
        [AllowEmptyString()]
        public string Value
        {
            get;
            set;
        }

        [Parameter()]
        public bool? OnlyMaxLimit
        {
            get;
            set;
        }

        [Parameter()]
        public bool? ValueIsFilter
        {
            get;
            set;
        }

        protected override void ProcessRecord()
        {
            TypeSwitch.Do(
                InputObject.BaseObject,
                TypeSwitch.Case<RunObjectLink>(i => i.Add(new RunObjectLinkLine(FieldName, TableFilterType, Value)
                {
                    OnlyMaxLimit = OnlyMaxLimit,
                    ValueIsFilter = ValueIsFilter
                })),
                TypeSwitch.Case<PartPageControl>(i => i.Properties.SubPageLink.Add(new RunObjectLinkLine(FieldName, TableFilterType, Value)
                {
                    OnlyMaxLimit = OnlyMaxLimit,
                    ValueIsFilter = ValueIsFilter
                })),
                TypeSwitch.Case<PartPageControlProperties>(i => i.SubPageLink.Add(new RunObjectLinkLine(FieldName, TableFilterType, Value)
                {
                    OnlyMaxLimit = OnlyMaxLimit,
                    ValueIsFilter = ValueIsFilter
                })),
                TypeSwitch.Case<DataItemQueryElement>(i => i.Properties.DataItemLink.Add(new QueryDataItemLinkLine(FieldName, ReferenceDataItem, Value))),
                TypeSwitch.Case<QueryDataItemLink>(i => i.Add(new QueryDataItemLinkLine(FieldName, ReferenceDataItem, Value))),
                TypeSwitch.Default(() => InvalidInputObject())
            );
        }

        protected void InvalidInputObject()
        {
            throw new ApplicationException("Cannot add links to this object.");
        }

        protected TableFilterType TableFilterType
        {
            get
            {
                if (Const.IsPresent)
                    return Core.TableFilterType.Const;
                if (Filter.IsPresent)
                    return Core.TableFilterType.Filter;
                if (Field.IsPresent)
                    return Core.TableFilterType.Field;

                throw new ArgumentOutOfRangeException("ExtendedTableFilterType");
            }
        }
    }
}
