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
    public class AddCBreezeVariable : Cmdlet, IDynamicParameters
    {
        private RuntimeDefinedParameter code = CreateScopeRuntimeDefinedParameter("Code", typeof(Code));
        private RuntimeDefinedParameter function = CreateScopeRuntimeDefinedParameter("Function", typeof(Function));
        private RuntimeDefinedParameter trigger = CreateScopeRuntimeDefinedParameter("Trigger", typeof(Trigger));
        private RuntimeDefinedParameter @event = CreateScopeRuntimeDefinedParameter("Event", typeof(Event));

        private static RuntimeDefinedParameter CreateScopeRuntimeDefinedParameter(string name, Type type)
        {
            var parameterAttribute = new ParameterAttribute();
            //parameterAttribute.Mandatory = true;
            parameterAttribute.ValueFromPipeline = true;

            var attributes = new Collection<Attribute> { parameterAttribute };

            return new RuntimeDefinedParameter(name, type, attributes);
        }

        private Scope GetScope()
        {
            if (code.IsSet)
                return Scope.Global;
            if (function.IsSet)
                return Scope.Function;
            if (trigger.IsSet)
                return Scope.Trigger;
            if (@event.IsSet)
                return Scope.Event;

            return Scope.Undefined;
        }

        private enum Scope
        {
            Undefined,
            Global,
            Function,
            Trigger,
            Event
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

        public SwitchParameter PassThru
        {
            get;
            set;
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
                switch (GetScope())
                {
                    case Scope.Global:
                        return (code.Value as Code).Variables;
                    case Scope.Function:
                        return (function.Value as Function).Variables;
                    case Scope.Trigger:
                        return (trigger.Value as Trigger).Variables;
                    case Scope.Event:
                        return (@event.Value as Event).Variables;
                    default:
                        return null;
                }
            }
        }

        public object GetDynamicParameters()
        {
            var parameters = new RuntimeDefinedParameterDictionary();
            var scope = GetScope();

            if (scope == Scope.Global || scope == Scope.Undefined)
            {
                parameters.Add(code.Name, code);
            }

            if (scope == Scope.Function || scope == Scope.Undefined)
            {
                parameters.Add(function.Name, function);
            }

            if (scope == Scope.Trigger || scope == Scope.Undefined)
            {
                parameters.Add(trigger.Name, trigger);
            }

            if (scope == Scope.Event || scope == Scope.Undefined)
            {
                parameters.Add(@event.Name, @event);
            }

            return parameters;
        }
    }
}
