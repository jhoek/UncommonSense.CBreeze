using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.Script
{
    public class ArrayParameter : ParameterBase
    {
        public ArrayParameter(string name, params Statement[] elements)
            : this(name, elements.AsEnumerable())
        {
        }

        public ArrayParameter(string name, IEnumerable<Statement> elements)
            : base(name)
        {
            Elements = elements;
        }

        public override string ToString(int indentation)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append($"{Indentation(indentation)}-{Name} ");
            stringBuilder.Append(string.Join(", ", Elements.Select(e => $"({e.ToString()})")));

            return stringBuilder.ToString();
        }

        public IEnumerable<Statement> Elements { get; }

        public override bool HasValue => Elements.Any();
    }
}