using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Contracts;

namespace UncommonSense.CBreeze.Core.Code.Variable
{
    public class AutomationVariable : Variable, IHasDimensions
    {
        public AutomationVariable(string name, string subType) : this(0, name, subType) { }
        public AutomationVariable(int id, string name, string subType) : base(id, name) { SubType = subType; }
        public string Dimensions { get; set; }
        public string SubType { get; }
        public override string TypeName => $"Automation \"{SubType}\"";
        public override VariableType Type => VariableType.Automation;
        public bool? WithEvents { get; set; }
    }
}