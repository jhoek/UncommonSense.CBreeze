using System.Collections.Generic;
using UncommonSense.CBreeze.Core.Code.Parameter;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Generic;

namespace UncommonSense.CBreeze.Core.Code.Variable
{
    public class Event : KeyedItem<int>, IHasName, IHasCodeLines, INode
    {
        public Event(int sourceID, string sourceName, int id, string name)
        {
            ID = id;
            Name = name;
            SourceID = sourceID;
            SourceName = sourceName;
            CodeLines = new CodeLines(this);
            Parameters = new EventParameters(this);
            Variables = new EventVariables(this);
        }

        public IEnumerable<INode> ChildNodes
        {
            get
            {
                yield return CodeLines;
                yield return Parameters;
                yield return Variables;
            }
        }

        public CodeLines CodeLines
        {
            get;
            protected set;
        }

        public Events Container
        {
            get;
            internal set;
        }

        public string Name
        {
            get;
            protected set;
        }

        public Parameters Parameters
        {
            get;
            protected set;
        }

        public INode ParentNode => Container;

        public int SourceID
        {
            get;
            protected set;
        }

        public string SourceName
        {
            get;
            protected set;
        }

        public Variables Variables
        {
            get;
            protected set;
        }

        public string GetName() => Name;
    }
}