using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Contracts;

namespace UncommonSense.CBreeze.Core.Code.Variable
{
    public class BigTextVariable : Variable, IHasDimensions
    {
        public BigTextVariable(string name) : this(0, name) { }
        public BigTextVariable(int id, string name) : base(id, name) { }
        public string Dimensions { get; set; }
        public override VariableType Type => VariableType.BigText;
    }
}