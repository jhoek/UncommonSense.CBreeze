using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Property.Enumeration;

namespace UncommonSense.CBreeze.Core.Code.Variable
{
    public class RecordVariable : Variable,IHasDimensions
    {
        public RecordVariable(string name, int subType) : this(0, name, subType)
        {
        }

        public RecordVariable(int id, string name, int subType)
            : base(id, name)
        {
            SubType = subType;
        }

        public override string TypeName => $"Record {SubType}";

        public string Dimensions
        {
            get;
            set;
        }

        public RecordSecurityFiltering? SecurityFiltering
        {
            get;
            set;
        }

        public int SubType
        {
            get;
            protected set;
        }

        public bool Temporary
        {
            get;
            set;
        }

        public override VariableType Type
        {
            get
            {
                return VariableType.Record;
            }
        }
    }
}