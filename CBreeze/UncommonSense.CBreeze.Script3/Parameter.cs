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

        public virtual void WriteTo(ScriptWriter writer, bool continuation, bool lineBreak)
        {
            writer.WriteIf(continuation, "`");
            writer.WriteLineIf(lineBreak);
        }
    }
}