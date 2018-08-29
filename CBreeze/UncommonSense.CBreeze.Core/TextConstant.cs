using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public class TextConstant : Variable
    {
        public TextConstant(string name) : this(0, name)
        {
        }

        public TextConstant(int id, string name)
            : base(id, name)
        {
            Values = new MultiLanguageValue();
        }

        public override VariableType Type => VariableType.TextConst;
        public override string TypeName => Values.Any() ? $"TextConst '{ValuesAsText}'" : "TextConst";
        public MultiLanguageValue Values { get; protected set; }
        public string ValuesAsText => string.Join(";", Values.OrderBy(t => t.LanguageID.GetLCIDFromLanguageCode()).Select(v => string.Format("{0}={1}", v.LanguageID, v.Value.TextConstantValue(v.LanguageID == "@@@", Values.Count()))));
    }
}