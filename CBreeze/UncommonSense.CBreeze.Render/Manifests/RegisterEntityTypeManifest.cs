using System;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Render
{
	public class RegisterEntityTypeManifest : RenderingManifest
	{
		internal RegisterEntityTypeManifest()
		{
		}

		public Table Table
		{
			get;
			internal set;
		}

        public IntegerTableField NoField
        {
            get;
            internal set;
        }

        public DateTableField CreationDateField
        {
            get;
            internal set;
        }

        public CodeTableField UserIDField
        {
            get;
            internal set;
        }

        public CodeTableField SourceCodeField
        {
            get;
            internal set;
        }
        
		public Page Page
		{
			get;
			internal set;
		}
	}
}

