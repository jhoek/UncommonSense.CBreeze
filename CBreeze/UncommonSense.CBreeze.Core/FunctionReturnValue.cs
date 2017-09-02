using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public class FunctionReturnValue : INode
    {
        internal FunctionReturnValue(Function function)
        {
            Function = function;
        }

        public IEnumerable<INode> ChildNodes
        {
            get
            {
                yield break;
            }
        }

        public int? DataLength
        {
            get;
            set;
        }

        public int? DefaultDataLength
        {
            get
            {
                if (!Type.HasValue)
                    return null;

                switch (Type.Value)
                {
                    case FunctionReturnValueType.Binary:
                        return 100;

                    case FunctionReturnValueType.Code:
                        return 10;

                    default:
                        return null;
                }
            }
        }

        public string Dimensions
        {
            get;
            set;
        }

        public Function Function { get; protected set; }

        public string Name
        {
            get;
            set;
        }

        public INode ParentNode => Function;

        public FunctionReturnValueType? Type
        {
            get;
            set;
        }
    }
}