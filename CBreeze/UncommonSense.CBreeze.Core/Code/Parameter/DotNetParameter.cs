using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core.Code.Parameter
{
    public class DotNetParameter : Parameter
    {
        public DotNetParameter(string name, string subType, bool var = false, int id = 0) : base(name, var, id)
        {
            SubType = subType;
        }

        public bool? RunOnClient
        {
            get;
            set;
        }

        public string SubType
        {
            get;
            protected set;
        }

        public bool? SuppressDispose
        {
            get;
            set;
        }

        public override ParameterType Type => ParameterType.DotNet;

        public override string TypeName
        {
            get
            {
                var runOnClient = RunOnClient.GetValueOrDefault() ? " RUNONCLIENT" : "";
                var suppressDispose = SuppressDispose.GetValueOrDefault() ? " SUPPRESSDISPOSE" : "";

                return $"DotNet \"{SubType}\"{runOnClient}{suppressDispose}";
            }
        }
    }
}