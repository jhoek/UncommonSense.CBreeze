using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class Event
    {
        private Int32 sourceID;
        private String sourceName;
        private Int32 id;
        private String name;
        private CodeLines codeLines = new CodeLines();
        private Parameters parameters = new Parameters();
        private Variables variables = new Variables();

        internal Event(Int32 sourceID, String sourceName, Int32 id, String name)
        {
            this.id = id;
            this.name = name;
            this.sourceID = sourceID;
            this.sourceName = sourceName;
        }

        public Int32 SourceID
        {
            get
            {
                return this.sourceID;
            }
        }

        public String SourceName
        {
            get
            {
                return this.sourceName;
            }
        }

        public Int32 ID
        {
            get
            {
                return this.id;
            }
        }

        public String Name
        {
            get
            {
                return this.name;
            }
        }

        public CodeLines CodeLines
        {
            get
            {
                return this.codeLines;
            }
        }

        public Parameters Parameters
        {
            get
            {
                return this.parameters;
            }
        }

        public Variables Variables
        {
            get
            {
                return this.variables;
            }
        }

    }
}
