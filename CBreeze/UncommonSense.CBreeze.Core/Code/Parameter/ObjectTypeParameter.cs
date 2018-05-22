using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core.Code.Parameter
{
#if NAV2017
    public class ObjectTypeParameter : Parameter
    {
        public ObjectTypeParameter(string name, bool var = false, int id = 0)
            : base(name, var, id)
        {
        }

        public override ParameterType Type => ParameterType.ObjectType;
    }
#endif
}
