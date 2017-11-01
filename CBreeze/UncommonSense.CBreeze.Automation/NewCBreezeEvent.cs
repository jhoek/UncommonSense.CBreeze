using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.New, "CBreezeEvent", DefaultParameterSetName = ParameterSetNames.NewWithoutID)]
    [OutputType(typeof(Event))]
    [Alias("Event")]
    public class NewCBreezeEvent : NewItemWithIDAndNameCmdlet<Event, int, PSObject>
    {
        [Parameter(Mandatory = true, Position = 2, ParameterSetName = ParameterSetNames.NewWithoutID)]
        [Parameter(Mandatory = true, Position = 3, ParameterSetName = ParameterSetNames.NewWithID)]
        [Parameter(Mandatory = true, Position = 2, ParameterSetName = ParameterSetNames.AddWithoutID)]
        [Parameter(Mandatory = true, Position = 3, ParameterSetName = ParameterSetNames.AddWithID)]
        public int SourceID
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, Position = 3, ParameterSetName = ParameterSetNames.NewWithoutID)]
        [Parameter(Mandatory = true, Position = 4, ParameterSetName = ParameterSetNames.NewWithID)]
        [Parameter(Mandatory = true, Position = 3, ParameterSetName = ParameterSetNames.AddWithoutID)]
        [Parameter(Mandatory = true, Position = 4, ParameterSetName = ParameterSetNames.AddWithID)]
        public string SourceName
        {
            get;
            set;
        }

        [Parameter(Position = 4, ParameterSetName = ParameterSetNames.NewWithoutID)]
        [Parameter(Position = 5, ParameterSetName = ParameterSetNames.NewWithID)]
        [Parameter(Position = 4, ParameterSetName = ParameterSetNames.AddWithoutID)]
        [Parameter(Position = 5, ParameterSetName = ParameterSetNames.AddWithID)]
        public ScriptBlock SubObjects
        {
            get; set;
        }

        protected override IEnumerable<Event> CreateItems()
        {
            var @event = new Event(SourceID, SourceName, ID, Name);

            if (SubObjects != null)
            {
                var subObjects = SubObjects.Invoke().Select(o => o.BaseObject);

                @event.Variables.AddRange(subObjects.OfType<Variable>());
                @event.Parameters.AddRange(subObjects.OfType<Parameter>());
                @event.CodeLines.AddRange(subObjects.OfType<string>());
            }

            yield return @event;
        }

        protected override void AddItemToInputObject(Event item, PSObject inputObject)
        {
            switch (inputObject.BaseObject)
            {
                case Table t:
                    AddItemToInputObject(item, t);
                    break;

                case Page p:
                    AddItemToInputObject(item, p);
                    break;

                case Report r:
                    AddItemToInputObject(item, r);
                    break;

                case Codeunit c:
                    AddItemToInputObject(item, c);
                    break;

                case Query q:
                    AddItemToInputObject(item, q);
                    break;

                case XmlPort x:
                    AddItemToInputObject(item, x);
                    break;

                case Code c:
                    AddItemToInputObject(item, c);
                    break;

                case Events e:
                    AddItemToInputObject(item, e);
                    break;

                default:
                    base.AddItemToInputObject(item, inputObject);
                    break;
            }
        }

        protected void AddItemToInputObject(Event item, Table table) => AddItemToInputObject(item, table.Code);

        protected void AddItemToInputObject(Event item, Page page) => AddItemToInputObject(item, page.Code);

        protected void AddItemToInputObject(Event item, Report report) => AddItemToInputObject(item, report.Code);

        protected void AddItemToInputObject(Event item, Codeunit codeunit) => AddItemToInputObject(item, codeunit.Code);

        protected void AddItemToInputObject(Event item, Query query) => AddItemToInputObject(item, query.Code);

        protected void AddItemToInputObject(Event item, XmlPort xmlPort) => AddItemToInputObject(item, xmlPort.Code);

        protected void AddItemToInputObject(Event item, Code code) => AddItemToInputObject(item, code.Events);

        protected void AddItemToInputObject(Event item, Events events) => events.Add(item);
    }
}