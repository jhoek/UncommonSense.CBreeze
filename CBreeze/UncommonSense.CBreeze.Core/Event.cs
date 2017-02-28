using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    public class Event : IHasParameters, IHasVariables, IHasCodeLines, INode
    {
        public Event(int sourceID, string sourceName, int id, string name)
        {
            ID = id;
            Name = name;
            SourceID = sourceID;
            SourceName = sourceName;
            CodeLines = new CodeLines(this);
            Parameters = new Parameters(this);
            Variables = new Variables(this);
        }

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

        public int ID
        {
            get;
            protected set;
        }

        public string Name
        {
            get;
            protected set;
        }

        public Events Container
        {
            get;
            internal set;
        }

        public CodeLines CodeLines
        {
            get;
            protected set;
        }

        public Parameters Parameters
        {
            get;
            protected set;
        }

        public Variables Variables
        {
            get;
            protected set;
        }

        public INode ParentNode => Container;

        public IEnumerable<INode> ChildNodes
        {
            get
            {
                yield return CodeLines;
                yield return Parameters;
                yield return Variables;
            }
        }
    }
}
