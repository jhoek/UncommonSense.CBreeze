﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Core.Page.Control;
using UncommonSense.CBreeze.Core.Property.Implementation;
using UncommonSense.CBreeze.Core.Table.Field;
using UncommonSense.CBreeze.Core.Table.Relation;
using UncommonSense.CBreeze.Write;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.New, "CBreezeTableRelation", DefaultParameterSetName = ParameterSetNames.NewWithoutID)]
    [Alias("TableRelation", "Add-CBreezeTableRelation")]
    public class NewCBreezeTableRelation : NewItemCmdlet<TableRelationLine, PSObject>
    {
        protected override void AddItemToInputObject(TableRelationLine item, PSObject inputObject)
        {
            switch (inputObject.BaseObject)
            {
                case TableField f:
                    (f.AllProperties["TableRelation"] as TableRelationProperty).Value.Add(item);
                    break;
                case PageControl c:
                    c.Properties.TableRelation.Add(item);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Don't know how to add a table relation to this InputObject.");
                    ;
            }
        }

        protected override IEnumerable<TableRelationLine> CreateItems()
        {
            var result = new TableRelationLine(TableName) { FieldName = FieldName };

            var subObjects =
                SubObjects?
                    .Invoke()
                    .Select(o => o.BaseObject)
                    ?? Enumerable.Empty<object>();

            result.Conditions.AddRange(subObjects.OfType<TableRelationCondition>());
            result.TableFilter.AddRange(subObjects.OfType<TableRelationTableFilterLine>());

            yield return result;
        }

        [Parameter(Position = 2)] public string FieldName { get; set; }
        [Parameter(Position = 3)] public ScriptBlock SubObjects { get; set; }
        [Parameter(Mandatory = true, Position = 1)] public string TableName { get; set; }
    }
}