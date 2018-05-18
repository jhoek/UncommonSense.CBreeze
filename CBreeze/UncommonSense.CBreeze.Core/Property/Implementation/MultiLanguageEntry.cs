using System.Linq;

namespace UncommonSense.CBreeze.Core.Property.Implementation
{
        public class MultiLanguageEntry
    {
        internal MultiLanguageEntry(string languageID, string value)
        {
            LanguageID = languageID;
            Value = value;
        }

        public string LanguageID
        {
            get;
            protected set;
        }

        public string Value
        {
            get;
            set;
        }

        public string QuotedValue
        {
            get
            {
                return RequiresQuotes ? Value.ForceQuoted() : Value;
            }
        }

        public bool RequiresQuotes
        {
            get
            {
                return 
                    Value != Value.Trim() ||
                    Value.Contains(';') ||
                    Value.Contains('=') ||    
                    Value == string.Empty;
            }
        }
    }
}
