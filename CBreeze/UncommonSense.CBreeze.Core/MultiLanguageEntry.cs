using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class MultiLanguageEntry
    {
        private String languageID;
        private String value;

        internal MultiLanguageEntry(String languageID, String value)
        {
            this.languageID = languageID;
            this.value = value;
        }

        public String LanguageID
        {
            get
            {
                return this.languageID;
            }
        }

        public String Value
        {
            get
            {
                return this.value;
            }
        }

    }
}
