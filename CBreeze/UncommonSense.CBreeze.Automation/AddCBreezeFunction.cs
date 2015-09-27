using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Utils;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeFunction")]
    public class AddCBreezeFunction : Cmdlet
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

        [Parameter()]
        public FunctionType? FunctionType
        {
            get;
            set;
        }

        [Parameter()]
        public string HandlerFunctions
        {
            get;
            set;
        }

        [Parameter()]
        public TransactionModel? TransactionModel
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

            foreach (var inputObject in InputObject)
            {
                var function = GetFunctions(inputObject).Add(new Function(GetFunctionID(inputObject), Name));
                function.Properties.Local = Local;
                function.Properties.FunctionType = FunctionType;
                function.Properties.HandlerFunctions = HandlerFunctions;
                function.Properties.TransactionModel = TransactionModel;

                function.ReturnValue.Name = ReturnValueName;
                function.ReturnValue.Type = ReturnValueType;
                function.ReturnValue.DataLength = ReturnValueDataLength;
                function.ReturnValue.Dimensions = ReturnValueDimensions;

                if (PassThru)
                    WriteObject(function);
            }
        }


        private int GetFunctionID(PSObject inputObject)
        {
            if (ID != 0)
                return ID;

            return Range.Except(GetFunctions(inputObject).Select(f => f.ID)).First();
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
