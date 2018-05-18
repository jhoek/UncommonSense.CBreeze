using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Property.Enumeration;

namespace UncommonSense.CBreeze.Core.Code.Variable
{
    public class RecordRefVariable : Variable,IHasDimensions
    {
        public RecordRefVariable(string name) : this(0, name)
        {
        }

        public RecordRefVariable(int id, string name)
            : base(id, name)
        {
        }

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

        public override VariableType Type
        {
            get
            {
                return VariableType.RecordRef;
            }
        }
    }
}