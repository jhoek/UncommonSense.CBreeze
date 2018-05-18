using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Property.Enumeration;

namespace UncommonSense.CBreeze.Core.Code.Parameter
{
    public class RecordRefParameter : Parameter
    {
        public RecordRefParameter(string name, bool var = false, int id = 0) : base(name, var, id)
        {
        }

        public RecordSecurityFiltering? SecurityFiltering
        {
            get;
            set;
        }

        public override ParameterType Type => ParameterType.RecordRef;

        public override string TypeName
        {
            get
            {
                var securityFiltering = SecurityFiltering.HasValue ? $" SECURITYFILTERING({SecurityFiltering.Value})" : "";
                return $"RecordRef{securityFiltering}";
            }
        }
    }
}