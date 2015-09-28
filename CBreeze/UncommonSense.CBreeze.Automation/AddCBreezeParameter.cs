using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    public abstract class AddCBreezeParameter : Cmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public PSObject InputObject
        {
            get;
            set;
        }

        [Parameter()]
        public SwitchParameter Var
        {
            get;
            set;
        }

        [Parameter(Mandatory=true,ParameterSetName="ID")]
        [ValidateRange(1, int.MaxValue)]
        public int ID
        {
            get;
            set;
        }

        [Parameter(Mandatory=true, ParameterSetName = "Range")]
        public IEnumerable<int> Range
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, Position = 1)]
        public string Name
        {
            get;
            set;
        }

        [Parameter()]
        public string Dimensions
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

        protected int GetParameterID(PSObject inputObject)
        {
            if (ID != 0)
                return ID;

            return Range.Except(GetParameters(inputObject).Select(p => p.ID)).First();
        }

        protected Parameters GetParameters(PSObject inputObject)
        {
            if (inputObject.BaseObject is Parameters)
                return (inputObject.BaseObject as Parameters);
            if (inputObject.BaseObject is Function)
                return (inputObject.BaseObject as Function).Parameters;
            if (inputObject.BaseObject is Event)
                return (inputObject.BaseObject as Event).Parameters;

            throw new ApplicationException("Cannot add parameters to this object.");
        }
    }
}
