// --------------------------------------------------------------------------------
// <auto-generated>
//      This code was generated by a tool.
//
//      Changes to this file may cause incorrect behaviour and will be lost if
//      the code is regenerated.
// </auto-generated>
// --------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class FunctionProperties : Properties
    {
        private FunctionTypeProperty functionType = new FunctionTypeProperty("FunctionType");
        private StringProperty handlerFunctions = new StringProperty("HandlerFunctions");
        private NullableBooleanProperty local = new NullableBooleanProperty("Local");
        private TransactionModelProperty transactionModel = new TransactionModelProperty("TransactionModel");

        internal FunctionProperties()
        {
            innerList.Add(functionType);
            innerList.Add(handlerFunctions);
            innerList.Add(local);
            innerList.Add(transactionModel);
        }

        public FunctionType? FunctionType
        {
            get
            {
                return this.functionType.Value;
            }
            set
            {
                this.functionType.Value = value;
            }
        }

      public string HandlerFunctions
        {
            get
            {
                return this.handlerFunctions.Value;
            }
            set
            {
                this.handlerFunctions.Value = value;
            }
        }

      public System.Boolean? Local
        {
            get
            {
                return this.local.Value;
            }
            set
            {
                this.local.Value = value;
            }
        }

        public TransactionModel? TransactionModel
        {
            get
            {
                return this.transactionModel.Value;
            }
            set
            {
                this.transactionModel.Value = value;
            }
        }
    }
}
