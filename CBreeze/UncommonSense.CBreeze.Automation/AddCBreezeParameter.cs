using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    public abstract class AddCBreezeParameter<T> : Cmdlet where T : Parameter
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

        [Parameter(Mandatory = true, ParameterSetName = "ID")]
        [ValidateRange(1, int.MaxValue)]
        public int ID
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "Range")]
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

        protected override void ProcessRecord()
        {
            var parameter = CreateParameter();
            SetParameterProperties(parameter);
            WriteParameterToPipeline(parameter);
        }

        protected abstract T CreateParameter();

        protected virtual void SetParameterProperties(T parameter)
        {
            parameter.Dimensions = Dimensions;
        }

        protected virtual void WriteParameterToPipeline(T parameter)
        {
            if (PassThru)
                WriteObject(parameter);
        }

        protected int GetParameterID()
        {
            if (ID != 0)
                return ID;

            return Range.Except(Parameters.Select(p => p.ID)).First();
        }

        protected Parameters Parameters
        {
            get
            {
                if (InputObject.BaseObject is Parameters)
                    return (InputObject.BaseObject as Parameters);
                if (InputObject.BaseObject is Function)
                    return (InputObject.BaseObject as Function).Parameters;
                if (InputObject.BaseObject is Event)
                    return (InputObject.BaseObject as Event).Parameters;

                throw new ApplicationException("Cannot add parameters to this object.");
            }
        }
    }
}
