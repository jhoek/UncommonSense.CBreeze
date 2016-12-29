using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.New, "CBreezeEvent")]
    public class NewCBreezeEvent : Cmdlet
    {
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

                subObjects.OfType<Variable>().ToList().ForEach(f => @event.Variables.Add(f));
                subObjects.OfType<Parameter>().ToList().ForEach(p => @event.Parameters.Add(p));
                subObjects.OfType<string>().ToList().ForEach(c => @event.CodeLines.Add(c));
            }

            return @event;
        }

        protected override void ProcessRecord()
        {
            WriteObject(CreateEvent());
        }
    }
}
