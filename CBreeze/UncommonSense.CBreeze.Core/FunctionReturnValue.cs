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

        public Function Function { get; protected set; }

        public string Dimensions
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public FunctionReturnValueType? Type
        {
            get;
            set;
        }

        public int? DataLength
        {
            get;
            set;
        }

        public INode ParentNode => Function;

        public IEnumerable<INode> ChildNodes
        {
            get
            {
                yield break;
            }
        }
    }
}
