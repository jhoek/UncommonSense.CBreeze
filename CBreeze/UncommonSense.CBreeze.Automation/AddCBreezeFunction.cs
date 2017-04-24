using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeFunction", DefaultParameterSetName = "Test")]
    public class AddCBreezeFunction : NewCBreezeFunction
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public PSObject InputObject
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
            var function = GetFunctions(InputObject).Add(CreateFunction());

            if (PassThru)
                WriteObject(function);
        }

        private Functions GetFunctions(PSObject inputObject)
        {
            if (inputObject.BaseObject is Functions)
                return (inputObject.BaseObject as Functions);
            if (inputObject.BaseObject is Code)
                return (inputObject.BaseObject as Code).Functions;

            if (inputObject.BaseObject is Table)
                return (inputObject.BaseObject as Table).Code.Functions;
            if (inputObject.BaseObject is Page)
                return (inputObject.BaseObject as Page).Code.Functions;
            if (inputObject.BaseObject is Report)
                return (inputObject.BaseObject as Report).Code.Functions;
            if (inputObject.BaseObject is Codeunit)
                return (inputObject.BaseObject as Codeunit).Code.Functions;
            if (inputObject.BaseObject is Query)
                return (inputObject.BaseObject as Query).Code.Functions;
            if (inputObject.BaseObject is XmlPort)
                return (inputObject.BaseObject as XmlPort).Code.Functions;

            throw new ApplicationException("Cannot add functions to this object.");
        }
    }
}