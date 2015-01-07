using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Render
{
	public class LedgerEntityTypeManifest : RenderingManifest
	{
		internal LedgerEntityTypeManifest()
		{
		}

		public Table Table
		{
			get;
			internal set;
		}

        public IntegerTableField EntryNoField
        {
            get;
            internal set;
        }

        public CodeTableField MasterEntityTypeField
        {
            get;
            internal set;
        }

        public TextTableField DescriptionField
        {
            get;
            internal set;
        }

        public DateTableField PostingDateField
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
