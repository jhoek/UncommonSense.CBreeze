using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Property.Enumeration;

namespace UncommonSense.CBreeze.Core.Code.Parameter
{
    public class RecordParameter : Parameter
    {
        public RecordParameter(string name, int subType, bool var = false, int id = 0)
            : base(name, var, id)
        {
            SubType = subType;
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

        public bool? Temporary
        {
            get;
            set;
        }

        public override ParameterType Type => ParameterType.Record;

        public override string TypeName
        {
            get
            {
                var securityFiltering = SecurityFiltering.HasValue ? $" SECURITYFILTERING({SecurityFiltering.Value})" : "";
                return $"Record {SubType}{securityFiltering}";
            }
        }
    }
}