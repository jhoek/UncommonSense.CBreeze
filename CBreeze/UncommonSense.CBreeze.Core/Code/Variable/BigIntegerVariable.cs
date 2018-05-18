using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Contracts;

namespace UncommonSense.CBreeze.Core.Code.Variable
{
    public class BigIntegerVariable : Variable, IHasDimensions
    {
        public BigIntegerVariable(string name) : this(0, name) { }
        public BigIntegerVariable(int id, string name) : base(id, name) { }
        public string Dimensions { get; set; }
        public override VariableType Type => VariableType.BigInteger;
    }
}