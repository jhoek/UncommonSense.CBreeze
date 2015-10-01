using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeVariable")]
    public class AddCBreezeVariable : CmdletWithDynamicParams
    {
        public AddCBreezeVariable()
        {
            IntegerSubType = new DynamicParameter<int>("SubType", true, 1, int.MaxValue);
            StringSubType = new DynamicParameter<string>("SubType", true);
            RecordSecurityFiltering = new DynamicParameter<RecordSecurityFiltering?>("SecurityFiltering", false);
            Temporary = new DynamicParameter<bool?>("Temporary", false);
            WithEvents = new DynamicParameter<bool?>("WithEvents", false);
        }

        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public PSObject[] InputObject
        {
            get;
            set;
        }

        [Parameter(Mandatory = true)]
        public VariableType Type
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
        } // ???

        [Parameter()]
        public SwitchParameter PassThru
        {
            get;
            set;
        }

        protected DynamicParameter<int> IntegerSubType
        {
            get;
            set;
        }

        protected DynamicParameter<string> StringSubType
        {
            get;
            set;
        }

        protected DynamicParameter<RecordSecurityFiltering?> RecordSecurityFiltering
        {
            get;
            set;
        }

        protected DynamicParameter<bool?> Temporary
        {
            get;
            set;
        }

        protected DynamicParameter<bool?> WithEvents
        {
            get;
            set;
        }

        protected override void ProcessRecord()
        {
            foreach (var inputObject in InputObject)
            {
                switch (Type)
                {
                    case VariableType.Action:
                        var actionVariable = GetVariables(inputObject).Add(new ActionVariable(GetVariableID(inputObject), Name));
                        actionVariable.Dimensions = Dimensions;
                        WriteVariable(actionVariable);
                        break;

                    case VariableType.Automation:
                        var automationVariable = GetVariables(inputObject).Add(new AutomationVariable(GetVariableID(inputObject), Name, StringSubType.Value));
                        automationVariable.Dimensions = Dimensions;
                        automationVariable.WithEvents = WithEvents.Value;
                        WriteVariable(automationVariable);
                        break;

                    case VariableType.Record:
                        var recordVariable = GetVariables(inputObject).Add(new RecordVariable(GetVariableID(inputObject), Name, IntegerSubType.Value));
                        recordVariable.Dimensions = Dimensions;
                        recordVariable.SecurityFiltering = RecordSecurityFiltering.Value;
                        recordVariable.Temporary = Temporary.Value;
                        WriteVariable(recordVariable);
                        break;
                }
            }
        }

        protected void WriteVariable(Variable variable)
        {
            if (PassThru)
                WriteObject(variable);
        }

        protected int GetVariableID(PSObject inputObject)
        {
            if (ID != 0)
                return ID;

            return Range.Except(GetVariables(inputObject).Select(v => v.ID)).First();
        }

        protected Variables GetVariables(PSObject inputObject)
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

        public override IEnumerable<RuntimeDefinedParameter> DynamicParameters
        {
            get
            {
                switch (Type)
                {
                    case VariableType.Record:
                        yield return IntegerSubType.RuntimeDefinedParameter;
                        yield return RecordSecurityFiltering.RuntimeDefinedParameter;
                        yield return Temporary.RuntimeDefinedParameter;
                        break;
                    case VariableType.Automation:
                        yield return StringSubType.RuntimeDefinedParameter;
                        yield return WithEvents.RuntimeDefinedParameter;
                        break;
                }
            }
        }
    }
}
