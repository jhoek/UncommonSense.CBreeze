using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Contracts;

namespace UncommonSense.CBreeze.Core.Code.Variable
{
    public class ActionVariable : Variable, IHasDimensions
    {
        public ActionVariable(string name) : this(0, name) { }
        public ActionVariable(int id, string name) : base(id, name) { }
        public string Dimensions { get; set; }
        public override VariableType Type => VariableType.Action;
    }
}