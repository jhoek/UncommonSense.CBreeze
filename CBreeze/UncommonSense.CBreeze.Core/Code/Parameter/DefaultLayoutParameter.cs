using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core.Code.Parameter
{
#if NAV2017
    public class DefaultLayoutParameter : Parameter
    {
        public DefaultLayoutParameter(string name, bool var = false, int id = 0)
            : base(name, var, id)
        {
        }

        public override ParameterType Type => ParameterType.DefaultLayout;
    }
#endif
}
