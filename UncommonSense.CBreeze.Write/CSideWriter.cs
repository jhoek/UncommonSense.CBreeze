using System.Text;
using System.IO;
using System.Globalization;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Write
{
    public class CSideWriter
    {
        private int column;
        private bool indentationPending = true;
        private TextWriter writer;
        private IndentationLevels indentationLevels = new IndentationLevels();

        public CSideWriter(TextWriter writer)
        {
            this.writer = writer;
        }

        public CSideWriter Indent()
        {
            this.indentationLevels.Indent();
            return this;
        }

        public CSideWriter Indent(int indentationLevel)
        {
            this.indentationLevels.Indent(indentationLevel);
            return this;
        }

        public CSideWriter Unindent()
        {
            this.indentationLevels.Unindent();
            return this;
        }

        protected void WriteIndentation()
        {
            if (indentationPending)
            {
                writer.Write(new string(' ', indentationLevels.Current));
                this.column += indentationLevels.Current;
                indentationPending = false;
            }
        }

        public CSideWriter Write(string text)
        {
            WriteIndentation();
            this.column += text.Length;
            writer.Write(text);

            return this;
        }

        public CSideWriter Write(string format, params object[] args)
        {
            return this.Write(string.Format(format, args));
        }

        public CSideWriter WriteLine(string text)
        {
            WriteIndentation();
            writer.WriteLine(text);

            this.column = 0;
            indentationPending = true;

            return this;
        }

        public CSideWriter WriteLine(string format, params object[] args)
        {
            return this.WriteLine(string.Format(format, args));
        }

        public int Column
        {
            get
            {
                return this.column;
            }
        }

        public TextWriter InnerWriter
        {
            get
            {
                return this.writer;
            }
        }
    }
}
