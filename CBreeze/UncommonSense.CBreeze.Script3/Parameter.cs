namespace UncommonSense.CBreeze.Script3
{
    public abstract class Parameter
    {
        public Parameter(string name)
        {
            Name = name;
        }

        public abstract bool HasValue { get; }
        public abstract bool IsMultiLine { get; }
        public string Name { get; }
        public bool OnCmdletLine { get; set; }

        public abstract void WriteTo(ScriptWriter writer);
    }
}