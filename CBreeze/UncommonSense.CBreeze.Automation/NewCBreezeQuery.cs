using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.New, "CBreezeQuery", DefaultParameterSetName = ParameterSetNames.NewWithoutID)]
    [OutputType(typeof(Query))]
    [Alias("Query", "Add-CBreezeQuery")]
    public class NewCBreezeQuery : NewCBreezeObject<Query>
    {
#if NAV2018
        [Parameter()] public string APIVersion { get; set; }
#endif
        [Parameter()] public Hashtable CaptionML { get; set; }
        [Parameter()] public string Description { get; set; }
#if NAV2018
        [Parameter()] public string EntityName { get; set; }
        [Parameter()] public string EntitySetName { get; set; }
#endif
        [Parameter()] public ScriptBlock OnBeforeOpen { get; set; }
        [Parameter()] public Permission[] Permissions { get; set; }
#if NAV2018
        [Parameter()] public QueryType? QueryType { get; set; }
#endif
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

#if NAV2018
            query.Properties.APIVersion = APIVersion;
#endif
            query.Properties.Description = Description;
#if NAV2018
            query.Properties.EntityName = EntityName;
            query.Properties.EntitySetName = EntitySetName;
#endif
            query.Properties.Permissions.Set(Permissions);
#if NAV2018
            query.Properties.QueryType = QueryType;
#endif
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