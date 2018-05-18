using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Contracts;

namespace UncommonSense.CBreeze.Core.Code.Variable
{
    public class BinaryVariable : Variable, IHasDimensions
    {
        public BinaryVariable(string name, int? dataLength = null) : this(0, name, dataLength) { } 
        public BinaryVariable(int id, string name, int? dataLength = null) : base(id, name) { DataLength = dataLength.Value == 0 ? 100 : dataLength.GetValueOrDefault(100); } 
        public int DataLength { get; protected set; } 
        public string Dimensions { get; set; } 
        public override string TypeName => $"Binary[{DataLength}]";
        public override VariableType Type => VariableType.Binary;
    }
}