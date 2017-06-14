using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.New, "CBreezeEvent")]
    [OutputType(typeof(Event))]
    [Alias("Event")]
    public class NewCBreezeEvent : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 2)]
        [ValidateRange(1, int.MaxValue)]
        public int ID
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, Position = 3)]
        public string Name
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, Position = 0)]
        public int SourceID
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, Position = 1)]
        public string SourceName
        {
            get;
            set;
        }

        [Parameter(Position = 4)]
        public ScriptBlock SubObjects
        {
            get; set;
        }

        protected Event CreateEvent()
        {
            var @event = new Event(SourceID, SourceName, ID, Name);

            if (SubObjects != null)
            {
                var subObjects = SubObjects.Invoke().Select(o => o.BaseObject);

                @event.Variables.AddRange(subObjects.OfType<Variable>());
                @event.Parameters.AddRange(subObjects.OfType<Parameter>());
                @event.CodeLines.AddRange(subObjects.OfType<string>());
            }

            return @event;
        }

        protected override void ProcessRecord()
        {
            WriteObject(CreateEvent());
        }
    }
}