using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Contracts;

namespace UncommonSense.CBreeze.Core.Code.Variable
{
    public class CodeVariable : Variable,IHasDimensions
    {
        public CodeVariable(string name, int? dataLength = null) : this(0, name, dataLength)
        {
        }

        public override string TypeName => $"Code[{DataLength}]";

        public CodeVariable(int id, string name, int? dataLength = null)
            : base(id, name)
        {
            DataLength = dataLength.Value == 0 ? 10 : dataLength.GetValueOrDefault(10);
        }

        public int DataLength
        {
            get;
            protected set;
        }

        public string Dimensions
        {
            get;
            set;
        }

        public bool? IncludeInDataset
        {
            get;
            set;
        }

        public override VariableType Type
        {
            get
            {
                return VariableType.Code;
            }
        }
    }
}