using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Core.Base;
using UncommonSense.CBreeze.Core.Code.Variable;
using UncommonSense.CBreeze.Core.Extension;
using UncommonSense.CBreeze.Core.Property.Enumeration;
using UncommonSense.CBreeze.Core.Property.Implementation;
using UncommonSense.CBreeze.Core.Query;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.New, "CBreezeQuery", DefaultParameterSetName = ParameterSetNames.NewWithoutID)]
    [OutputType(typeof(Query))]
    [Alias("Query", "Add-CBreezeQuery")]
    public class NewCBreezeQuery : NewCBreezeObject<Query>
    {
        [Parameter()] public Hashtable CaptionML { get; set; }
        [Parameter()] public string Description { get; set; }
        [Parameter()] public ScriptBlock OnBeforeOpen { get; set;}
        [Parameter()] public Permission[] Permissions { get; set; }
        [Parameter()] public ReadState? ReadState { get; set; }
        [Parameter()] [ValidateRange(0, int.MaxValue)] public int? TopNumberOfRows { get; set; }

        protected override void AddItemToInputObject(Query item, Application inputObject)
        {
            inputObject.Queries.Add(item);
        }

        protected override IEnumerable<Query> CreateItems()
        {
            var query = new Query(ID, Name);
            SetObjectProperties(query);

            query.Properties.Description = Description;
            query.Properties.Permissions.Set(Permissions);
            query.Properties.ReadState = ReadState;
            query.Properties.TopNumberOfRows = TopNumberOfRows;
            query.Properties.CaptionML.Set(CaptionML);
            query.Properties.OnBeforeOpen.Set(OnBeforeOpen);

            if (AutoCaption)
                query.AutoCaption();

            if (SubObjects != null)
            {
                var subObjects = SubObjects.Invoke().Select(o => o.BaseObject);
                query.Code.Documentation.CodeLines.AddRange(subObjects.OfType<string>());
                query.Properties.OrderBy.AddRange(subObjects.OfType<QueryOrderByLine>());
                query.Elements.AddRange(subObjects.OfType<QueryElement>());
                query.Code.Functions.AddRange(subObjects.OfType<Function>());
                query.Code.Variables.AddRange(subObjects.OfType<Variable>());
                query.Code.Events.AddRange(subObjects.OfType<Event>());
            }

            yield return query;
        }
    }
}