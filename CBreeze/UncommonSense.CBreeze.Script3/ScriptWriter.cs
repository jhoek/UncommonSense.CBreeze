using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.Script3
{
    public class ScriptWriter
    {
        public ScriptWriter(TextWriter innerWriter)
        {
            InnerWriter = innerWriter;
        }

        public int IndentationLevel { get; protected set; }
        public TextWriter InnerWriter { get; }
        protected bool IndentationPending { get; set; }
        protected string IndentationText => new string(' ', IndentationLevel * 2);

        public void Indent() => IndentationLevel++;

        public void Unindent() => IndentationLevel = Math.Max(IndentationLevel - 1, 0);

        public void Write(object value)
        {
            WriteIndentation();
            InnerWriter.Write(value);
        }

        public void WriteIf(bool condition, object value)
        {
            if (condition)
            {
                Write(value);
            }
        }

        public void WriteLine()
        {
            InnerWriter.WriteLine();
            IndentationPending = true;
        }

        public void WriteLine(object value)
        {
            WriteIndentation();
            InnerWriter.WriteLine(value);

            IndentationPending = true;
        }

        public void WriteLineIf(bool condition)
        {
            if (condition)
            {
                WriteLine();
            }
        }

        public void WriteLineIf(bool condition, object value)
        {
            if (condition)
            {
                WriteLine(value);
            }
        }

        protected void WriteIndentation()
        {
            if (IndentationPending)
            {
                InnerWriter.Write(IndentationText);
                IndentationPending = false;
            }
        }
    }
}