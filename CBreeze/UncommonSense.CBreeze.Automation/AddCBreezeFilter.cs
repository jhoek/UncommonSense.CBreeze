using System;
using System.Management.Automation;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeFilter")]
    [Alias("_Filter")]
    public class AddCBreezeFilter : Cmdlet
    {
        // FIXME: Avoid TypeSwitch

        [Parameter(Mandatory = true, Position = 0)]
        public string FieldName
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public PSObject InputObject
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

        [Parameter(Mandatory = true, Position = 1)]
        public SimpleTableFilterType Type
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, Position = 2)]
        [AllowEmptyString]
        public string Value
        {
            get;
            set;
        }

        protected void InvalidInputObject()
        {
            throw new ArgumentOutOfRangeException("Cannot add a filter to this object.");
        }

        protected void PassThruInputObject(object inputObject)
        {
            if (PassThru)
                WriteObject(inputObject);
        }

        protected override void ProcessRecord()
        {
            // FIXME: Should also work as subobject of PartPageControl, and everything else that has
            //        a TableView: XmlPortTableAttribute, PartPageControl, PageAction, XmlPortRequestPage,
            //        ReportRequestPage, XmlPortTableElement, DataItemReportElement,Page

            TypeSwitch.Do(
                InputObject.BaseObject,
                TypeSwitch.Case<PartPageControl>(i => i.Properties.SubPageView.TableFilter.Add(new TableFilterLine(FieldName, Type, Value))),
                TypeSwitch.Case<TableView>(i => i.TableFilter.Add(new TableFilterLine(FieldName, Type, Value))),
                TypeSwitch.Case<TableFilter>(i => i.Add(new TableFilterLine(FieldName, Type, Value))),

                TypeSwitch.Case<DataItemQueryElement>(i => i.Properties.DataItemTableFilter.Add(new DataItemQueryElementTableFilterLine(FieldName, Type, Value))),
                TypeSwitch.Case<DataItemQueryElementTableFilter>(i => i.Add(new DataItemQueryElementTableFilterLine(FieldName, Type, Value))),
                TypeSwitch.Case<ColumnQueryElement>(i => i.Properties.ColumnFilter.Add(new ColumnFilterLine(FieldName, Type, Value))),
                TypeSwitch.Case<ColumnFilter>(i => i.Add(new ColumnFilterLine(FieldName, Type, Value))),
                TypeSwitch.Case<FilterQueryElement>(i => i.Properties.ColumnFilter.Add(new ColumnFilterLine(FieldName, Type, Value))),
                TypeSwitch.Default(() => InvalidInputObject())
                );

            PassThruInputObject(InputObject);
        }
    }
}