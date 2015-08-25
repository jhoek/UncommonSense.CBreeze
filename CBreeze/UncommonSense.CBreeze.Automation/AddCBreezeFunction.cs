using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeFunction")]
    public class AddCBreezeFunction : AddCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public PSObject InputObject
        {
            get;
            set;
        }

        [Parameter()]
        [ValidateRange(1, int.MaxValue)]
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

        protected override System.Collections.IEnumerable AddedObjects
        {
            get
            {
                ID = AutoAssignID(ID);

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

                var function = Functions.Add(new Function(ID, Name));
                function.Properties.Local = Local;
                function.Properties.FunctionType = FunctionType;
                function.Properties.HandlerFunctions = HandlerFunctions;
                function.Properties.TransactionModel = TransactionModel;

                function.ReturnValue.Name = ReturnValueName;
                function.ReturnValue.Type = ReturnValueType;
                function.ReturnValue.DataLength = ReturnValueDataLength;
                function.ReturnValue.Dimensions = ReturnValueDimensions;

                yield return function;
            }
        }

        private int AutoAssignID(int id)
        {
            if (id != 0)
                return id;

            if (!Functions.Any())
                return 1;

            return Functions.Last().ID + 1;
        }

        private Functions Functions
        {
            get
            {
                if (InputObject.BaseObject is Functions)
                    return (InputObject.BaseObject as Functions);
                if (InputObject.BaseObject is Code)
                    return (InputObject.BaseObject as Code).Functions;

                if (InputObject.BaseObject is Table)
                    return (InputObject.BaseObject as Table).Code.Functions;
                if (InputObject.BaseObject is Page)
                    return (InputObject.BaseObject as Page).Code.Functions;
                if (InputObject.BaseObject is Report)
                    return (InputObject.BaseObject as Report).Code.Functions;
                if (InputObject.BaseObject is Codeunit)
                    return (InputObject.BaseObject as Codeunit).Code.Functions;
                if (InputObject.BaseObject is Query)
                    return (InputObject.BaseObject as Query).Code.Functions;
                if (InputObject.BaseObject is XmlPort)
                    return (InputObject.BaseObject as XmlPort).Code.Functions;

                throw new ApplicationException("Cannot add functions to this object.");
            }
        }
    }
}
