using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Contracts;

namespace UncommonSense.CBreeze.Core.Code.Variable
{
#if NAV2016

    public class TableConnectionTypeVariable : Variable,IHasDimensions
    {
        public TableConnectionTypeVariable(string name) : this(0, name)
        {
        }

        public TableConnectionTypeVariable(int id, string name)
            : base(id, name)
        {
        }

        public override VariableType Type
        {
            get
            {
                return VariableType.TableConnectionType;
            }
        }

        public string Dimensions
        {
            get;
            set;
        }
    }

#endif
}