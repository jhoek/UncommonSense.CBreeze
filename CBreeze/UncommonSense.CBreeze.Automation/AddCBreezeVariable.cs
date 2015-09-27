using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    public abstract class AddCBreezeVariable : Cmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public PSObject[] InputObject
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

        private Variables GetVariables(PSObject inputObject)
        {
            if (inputObject.BaseObject is Table)
                return (inputObject.BaseObject as Table).Code.Variables;
            if (inputObject.BaseObject is Page)
                return (inputObject.BaseObject as Page).Code.Variables;
            if (inputObject.BaseObject is Report)
                return (inputObject.BaseObject as Report).Code.Variables;
            if (inputObject.BaseObject is Codeunit)
                return (inputObject.BaseObject as Codeunit).Code.Variables;
            if (inputObject.BaseObject is Query)
                return (inputObject.BaseObject as Query).Code.Variables;
            if (inputObject.BaseObject is XmlPort)
                return (inputObject.BaseObject as XmlPort).Code.Variables;

            if (inputObject.BaseObject is Code)
                return (inputObject.BaseObject as Code).Variables;

            if (inputObject.BaseObject is Function)
                return (inputObject.BaseObject as Function).Variables;
            if (inputObject.BaseObject is Trigger)
                return (inputObject.BaseObject as Trigger).Variables;
            if (inputObject.BaseObject is Event)
                return (inputObject.BaseObject as Event).Variables;

            throw new ApplicationException("Cannot add variables to this object.");
        }
    }
}
