using System;
using System.Collections.Generic;
using System.Management.Automation;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Core.Page.Action;
using UncommonSense.CBreeze.Core.Page.Control;
using UncommonSense.CBreeze.Core.Property.Implementation;
using UncommonSense.CBreeze.Core.Query;
using UncommonSense.CBreeze.Core.Report;
using UncommonSense.CBreeze.Core.Table.Field;
using UncommonSense.CBreeze.Core.Table.Field.Properties;
using UncommonSense.CBreeze.Core.XmlPort;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.New, "CBreezeFilter", DefaultParameterSetName = ParameterSetNames.NewWithoutID)]
    [Alias("TableFilter", "Add-CBreezeFilter")]
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
                case PageAction a:
                    a.Properties.RunPageView.TableFilter.Add(item);
                    break;

                case PageControlPart c:
                    c.Properties.SubPageView.TableFilter.Add(item);
                    break;

                case DataItemReportElement e:
                    e.Properties.DataItemTableView.TableFilter.Add(item);
                    break;

                case DataItemQueryElement e:
                    e.Properties.DataItemTableFilter.Add(item);
                    break;

                case TableView v:
                    v.TableFilter.Add(item);
                    break;

                case TableFilter f:
                    f.Add(item);
                    break;

                case XmlPortTableAttribute a:
                    a.Properties.SourceTableView.TableFilter.Add(item);
                    break;

                case XmlPortTableElement e:
                    e.Properties.SourceTableView.TableFilter.Add(item);
                    break;

                case ColumnQueryElement e:
                    e.Properties.ColumnFilter.Add(item);
                    break;

                case FilterQueryElement e:
                    e.Properties.ColumnFilter.Add(item);
                    break;

                default:
                    base.AddItemToInputObject(item, inputObject);
                    break;
            }
        }

        protected override IEnumerable<TableFilterLine> CreateItems()
        {
            yield return new TableFilterLine(FieldName, Type, Value);
        }
    }
}