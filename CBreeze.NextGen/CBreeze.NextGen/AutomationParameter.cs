namespace CBreeze.NextGen
{
    public class AutomationParameter : Parameter
    {
        public AutomationParameter(int uid, string name, string subType)
            : base(uid, name)
        {
            SubType = subType;
        }

        public override string ToString()
        {
            return "AutomationParameter";
        }
        
        public override ParameterType Type
        {
            get
            {
                return ParameterType.Automation;
            }
        }
        
        public string SubType
        {
            get;
            internal set;
        }
    }
}
