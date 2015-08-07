using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    // This cmdlet used to have parameter sets for each combination of scope (Global, Function, Trigger, Event) 
    // and variable type (e.g. Record). The scope aspect was controlled by the type of object received
    // via the pipeline (Code, Function, Trigger, Event).

    // Alternatively, we could have accepted a Variables collection instead of the Code, Function, Trigger 
    // and Event objects. However, Variables is an IEnumerable<Variable>, so PowerShell would have 
    // unravelled it. To work around this, users would have needed to put the variables collection in a 
    // single-element array, like this: (,$MyTable.Code.Variables) | Add-CBreezeVariable ...

    // In the original design, users could do this: $MyTable.Code | Add-CBreezeVariable ... or 
    // $MyFunction | Add-CBreezeVariable ... I felt this was more intuitive, even if it implied a more
    // complex set of parametersetnames. 

    // Sadly, however, PowerShell is unable to handle this many unique parameter sets. :(

    [Cmdlet(VerbsCommon.Add, "CBreezeVariable")]
    public class AddCBreezeVariable : Cmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public PSObject InputObject
        {
            get;
            set;
        }

        public SwitchParameter PassThru
        {
            get;
            set;
        }

        [Parameter()]
        public int ID
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

        [Parameter(Mandatory = true, ParameterSetName = "Option", Position = 0)]
        public SwitchParameter Option
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "Record", Position = 0)]
        public SwitchParameter Record
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "Option")]
        public string OptionString
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "Record")]
        public int SubType
        {
            get;
            set;
        }

        private VariableType GetVariableType()
        {
            if (Record.IsPresent)
                return VariableType.Record;
            if (Option.IsPresent)
                return VariableType.Option;

            // FIXME

            throw new ArgumentOutOfRangeException();
        }

        protected override void ProcessRecord()
        {
            ID = AutoAssignID(ID);

            switch (GetVariableType())
            {
                case VariableType.Option:
                    var optionVariable = Variables.AddOptionVariable(ID, Name);
                    optionVariable.OptionString = OptionString;
                    optionVariable.Dimensions = Dimensions;
                    this.WriteObjectIf(PassThru, optionVariable);
                    break;

                case VariableType.Record:
                    var recordVariable = Variables.AddRecordVariable(ID, Name, SubType);
                    recordVariable.Dimensions = Dimensions;
                    this.WriteObjectIf(PassThru, recordVariable);
                    break;

                // FIXME
            }
        }

        private int AutoAssignID(int id)
        {
            if (id != 0)
                return id;

            if (!Variables.Any())
                return 1;

            return Variables.Last().ID + 1;
        }

        private Variables Variables
        {
            get
            {
                if (InputObject.BaseObject is Table)
                    return (InputObject.BaseObject as Table).Code.Variables;
                if (InputObject.BaseObject is Page)
                    return (InputObject.BaseObject as Page).Code.Variables;
                if (InputObject.BaseObject is Report)
                    return (InputObject.BaseObject as Report).Code.Variables;
                if (InputObject.BaseObject is Codeunit)
                    return (InputObject.BaseObject as Codeunit).Code.Variables;
                if (InputObject.BaseObject is Query)
                    return (InputObject.BaseObject as Query).Code.Variables;
                if (InputObject.BaseObject is XmlPort)
                    return (InputObject.BaseObject as XmlPort).Code.Variables;

                if (InputObject.BaseObject is Code)
                    return (InputObject.BaseObject as Code).Variables;

                if (InputObject.BaseObject is Function)
                    return (InputObject.BaseObject as Function).Variables;
                if (InputObject.BaseObject is Trigger)
                    return (InputObject.BaseObject as Trigger).Variables;
                if (InputObject.BaseObject is Event)
                    return (InputObject.BaseObject as Event).Variables;

                throw new ApplicationException("Cannot add variables to this object.");
            }
        }
    }
}
