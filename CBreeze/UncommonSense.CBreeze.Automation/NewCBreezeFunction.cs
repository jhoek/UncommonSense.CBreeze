using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.New, "CBreezeFunction", DefaultParameterSetName = "Test")]
    public class NewCBreezeFunction : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 0)]
        [Alias("Range")]
        public PSObject ID
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
        public bool? Local
        {
            get;
            set;
        }

        [Parameter()]
        public string ReturnValueName
        {
            get;
            set;
        }

        [Parameter()]
        public FunctionReturnValueType? ReturnValueType
        {
            get;
            set;
        }

        [Parameter()]
        [ValidateRange(1, int.MaxValue)]
        public int? ReturnValueDataLength
        {
            get;
            set;
        }

        [Parameter()]
        public string ReturnValueDimensions
        {
            get;
            set;
        }

        [Parameter(ParameterSetName = "Test")]
        public TestFunctionType? TestFunctionType
        {
            get;
            set;
        }

        [Parameter(ParameterSetName = "Test")]
        public string HandlerFunctions
        {
            get;
            set;
        }

        [Parameter(ParameterSetName = "Test")]
        public TransactionModel? TransactionModel
        {
            get;
            set;
        }

#if NAV2015
        [Parameter(ParameterSetName = "Upgrade")]
        public UpgradeFunctionType? UpgradeFunctionType
        {
            get;
            set;
        }
#endif

#if NAV2016
        [Parameter(Mandatory = true, ParameterSetName = "EventSubscriber")]
        public SwitchParameter EventSubscriber
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "BusinessEvent")]
        public SwitchParameter BusinessEvent
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "IntegrationEvent")]
        public SwitchParameter IntegrationEvent
        {
            get;
            set;
        }

        [Parameter(ParameterSetName = "BusinessEvent")]
        [Parameter(ParameterSetName = "IntegrationEvent")]
        public bool? IncludeSender
        {
            get;
            set;
        }

        [Parameter(ParameterSetName = "IntegrationEvent")]
        public bool? GlobalVarAccess
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "EventSubscriber")]
        public ObjectType EventPublisherObjectType
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "EventSubscriber")]
        public int EventPublisherObjectID
        {
            get;
            set;
        }

        [Parameter(ParameterSetName = "EventSubscriber")]
        public string EventPublisherElement
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "EventSubscriber")]
        public string EventFunction
        {
            get;
            set;
        }

        [Parameter(ParameterSetName = "EventSubscriber")]
        public MissingAction? OnMissingLicense
        {
            get;
            set;
        }

        [Parameter(ParameterSetName = "EventSubscriber")]
        public MissingAction? OnMissingPermission
        {
            get;
            set;
        }

        [Parameter()]
        public bool? TryFunction
        {
            get;
            set;
        }
#endif

        [Parameter(Position=2)]
        public ScriptBlock SubObjects
        {
            get; set;
        }

        protected Function CreateFunction()
        {
            if (ReturnValueType.HasValue && (ReturnValueDataLength ?? 0) == 0)
            {
                switch (ReturnValueType.Value)
                {
                    case FunctionReturnValueType.Text:
                        ReturnValueDataLength = 30;
                        break;
                    case FunctionReturnValueType.Code:
                        ReturnValueDataLength = 10;
                        break;
                }
            }

            var function = new Function(ID.GetID(null, 0), Name);
            function.Local = Local;
            function.TestFunctionType = TestFunctionType;
            function.HandlerFunctions = HandlerFunctions;
            function.TransactionModel = TransactionModel;
#if NAV2015
            function.UpgradeFunctionType = UpgradeFunctionType;
#endif
#if NAV2016
            if (EventSubscriber)
            {
                function.Event = EventPublisherSubscriber.Subscriber;
                function.EventPublisherObject.Type = EventPublisherObjectType;
                function.EventPublisherObject.ID = EventPublisherObjectID;
                function.EventPublisherElement = EventPublisherElement;
                function.EventFunction = EventFunction;
                function.OnMissingLicense = OnMissingLicense;
                function.OnMissingPermission = OnMissingPermission;
            }
            else if (IntegrationEvent)
            {
                function.Event = EventPublisherSubscriber.Publisher;
                function.EventType = EventType.Integration;
                function.IncludeSender = IncludeSender;
                function.GlobalVarAccess = GlobalVarAccess;
            }
            else if (BusinessEvent)
            {
                function.Event = EventPublisherSubscriber.Publisher;
                function.EventType = EventType.Business;
                function.IncludeSender = IncludeSender;
            }

            function.TryFunction = TryFunction;
#endif
            function.ReturnValue.Name = ReturnValueName;
            function.ReturnValue.Type = ReturnValueType;
            function.ReturnValue.DataLength = ReturnValueDataLength;
            function.ReturnValue.Dimensions = ReturnValueDimensions;

            if (SubObjects != null)
            {
                var subObjects = SubObjects.Invoke().Select(o => o.BaseObject);

                subObjects.OfType<Variable>().ToList().ForEach(f => function.Variables.Add(f));
                subObjects.OfType<Parameter>().ToList().ForEach(p => function.Parameters.Add(p));
                subObjects.OfType<string>().ToList().ForEach(c => function.CodeLines.Add(c));
            }

            return function;
        }

        protected override void ProcessRecord()
        {
            WriteObject(CreateFunction());
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
