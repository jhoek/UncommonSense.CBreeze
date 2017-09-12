using System;
using System.Collections.Generic;
using System.Management.Automation;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.New, "CBreezeFilter", DefaultParameterSetName = ParameterSetNames.NewWithoutID)]
    [Alias("TableFilter")]
    public class NewCBreezeTableFilter : NewItemCmdlet<TableFilterLine, PSObject>
    {
        [Parameter(Mandatory = true, Position = 1)]
        public string FieldName
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, Position = 2)]
        public SimpleTableFilterType Type
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, Position = 3)]
        [AllowEmptyString]
        public string Value
        {
            get;
            set;
        }

        protected override void AddItemToInputObject(TableFilterLine item, PSObject inputObject)
        {
            switch (inputObject.BaseObject)
            {
                case PartPageControl c:
                    c.Properties.SubPageView.TableFilter.Add(item);
                    break;

                case TableView v:
                    v.TableFilter.Add(item);
                    break;

                case TableFilter f:
                    f.Add(item);
                    break;

                default:
                    base.AddItemToInputObject(item, inputObject);
                    break;
            }
        }

        protected override IEnumerable<TableFilterLine> CreateItems()
        {
            // FIXME: Should also work as subobject of PartPageControl, and everything else that has
            //        a TableView: XmlPortTableAttribute, PartPageControl, PageAction, XmlPortRequestPage,
            //        ReportRequestPage, XmlPortTableElement, DataItemReportElement,Page

            yield return new TableFilterLine(FieldName, Type, Value);
        }
    }
}