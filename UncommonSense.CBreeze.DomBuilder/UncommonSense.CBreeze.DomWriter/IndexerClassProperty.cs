using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.DomWriter
{
    public class IndexerClassProperty : ClassProperty
    {
        private string indexerName;
        private string indexerTypeName;

        public IndexerClassProperty(string typeName, string indexerName, string indexerTypeName)
            : base("this", typeName)
        {
            this.indexerName = indexerName;
            this.indexerTypeName = indexerTypeName;
        }

        public string IndexerName
        {
            get
            {
                return this.indexerName;
            }
        }

        public string IndexerTypeName
        {
            get
            {
                return this.indexerTypeName;
            }
        }
    }
}
