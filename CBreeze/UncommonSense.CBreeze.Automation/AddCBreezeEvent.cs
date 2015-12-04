using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeEvent")]
    public class AddCBreezeEvent : Cmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public PSObject InputObject
        {
            get;
            set;
        }

        [Parameter(Mandatory = true)]
        [ValidateRange(1, int.MaxValue)]
        public int ID
        {
            get;
            set;
        }

        [Parameter(Mandatory = true)]
        public string Name
        {
            get;
            set;
        }

        [Parameter(Mandatory = true)]
        public int SourceID
        {
            get;
            set;
        }

        [Parameter(Mandatory = true)]
        public string SourceName
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

        protected override void ProcessRecord()
        {
            var @event = GetEvents(InputObject).Add(new Event(SourceID, SourceName, ID, Name));
            
            if (PassThru)
                WriteObject(@event);
        }

        protected Events GetEvents(PSObject inputObject)
        {
            if (inputObject.BaseObject is Events)
                return (inputObject.BaseObject as Events);

            if (inputObject.BaseObject is Code)
                return (inputObject.BaseObject as Code).Events;

            if (inputObject.BaseObject is Table)
                return (inputObject.BaseObject as Table).Code.Events;
            if (inputObject.BaseObject is Page)
                return (inputObject.BaseObject as Page).Code.Events;
            if (inputObject.BaseObject is Report)
                return (inputObject.BaseObject as Report).Code.Events;
            if (inputObject.BaseObject is Codeunit)
                return (inputObject.BaseObject as Codeunit).Code.Events;
            if (inputObject.BaseObject is Query)
                return (inputObject.BaseObject as Query).Code.Events;
            if (inputObject.BaseObject is XmlPort)
                return (inputObject.BaseObject as XmlPort).Code.Events;

            throw new ApplicationException("Cannot add events to this object.");
        }
    }
}
