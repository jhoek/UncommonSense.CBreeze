using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Core.Property.Implementation;
using UncommonSense.CBreeze.Core.XmlPort;

namespace UncommonSense.CBreeze.Script
{
    public class SimpleParameter : ParameterBase
    {
        public SimpleParameter(string name, object value)
            : base(name)
        {
            Value = value;
        }

        public override bool HasValue => Value != null;

        public System.Object Value { get; protected set; }

        public string ValueAsString
        {
            get
            {
                switch (Value)
                {
                    case bool b:
                        return (b ? "$true" : "$false");

                    case string s:
                        return $"'{s.Replace("'", "''")}'";

                    case DateTime d:
                        return $"'{d}'";

                    case decimal d:
                        return d.ToString(CultureInfo.InvariantCulture);

                    case IEnumerable<string> e:
                        return string.Join(", ", e.Select(s => $"'{s}'"));

                    case MultiLanguageValue m:
                        return $"@{{ {string.Join("; ", m.Select(e => $"'{e.LanguageID}' = '{e.Value.Replace("'", "''") }'")) } }}";

                    case XmlPortNamespaces n:
                        return $"([Ordered]@{{ {string.Join("; ", n.Select(e => $"'{e.Prefix}' = '{e.Namespace.Replace("'", "''") }'")) } }})";

                    case DecimalPlaces d:
                        return $"{d.AtLeast}:{d.AtMost}";

                    case Invocation i:
                        return $"({i.ToString()})";

                    default:
                        return Value.ToString();
                }
            }
        }

        public override string ToString(int indentation) => $"{Indentation(indentation)}-{Name} {ValueAsString}";
    }
}