using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml;
using System.Xml.Linq;

namespace UncommonSense.CBreeze.Core
{
    public class CodeLines : Collection<string>, INode
    {
        internal CodeLines(IHasCodeLines container)
        {
            Container = container;
        }

        public IEnumerable<INode> ChildNodes
        {
            get
            {
                yield break;
            }
        }

        public IHasCodeLines Container { get; protected set; }

        public INode ParentNode => Container;

        public new void Add(string text)
        {
            base.Add(text);
        }

        public void Set(object value)
        {
            Clear();

            switch (value)
            {
                case null:
                    break;
                case string s:
                    Set(s.Split(new string[] { Environment.NewLine }, StringSplitOptions.None));
                    break;
                case IEnumerable<string> e:
                    AddRange(e);
                    break;
                case XmlDocument x:
                    Set(x.OuterXml);
                    break;
                case XDocument d:
                    Set(d.ToString());
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"Don't know how to populate code lines with a {value.GetType().FullName}.");
            }
        }

        public void Add(string format, params object[] args)
        {
            base.Add(string.Format(format, args));
        }

        public void Insert(int index, string format, params object[] args)
        {
            base.Insert(index, string.Format(format, args));
        }
    }
}
