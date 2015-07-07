namespace CBreeze.NextGen
{
    public partial class AutomationParameter : Parameter
    {
        public AutomationParameter(int uid, string name, string subType)
            : base(uid, name)
        {
            SubType = subType;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}", "AutomationParameter", UID, Name, SubType);
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
