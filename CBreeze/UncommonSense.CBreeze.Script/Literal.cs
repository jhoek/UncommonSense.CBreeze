using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.Script
{
    public class Literal : Statement
    {
        public Literal(string text)
        {
            Text = text;
        }

        public override string ToString(int indentation) => $"{Indentation(indentation)}'{Text.Escape()}'{Environment.NewLine}";

        public string Text { get; }
    }
}