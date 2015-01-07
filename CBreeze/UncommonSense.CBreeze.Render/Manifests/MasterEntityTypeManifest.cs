using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Render
{
	public class MasterEntityTypeManifest : RenderingManifest
	{
		internal MasterEntityTypeManifest()
		{
		}

		public Table Table
		{
			get;
			internal set;
		}

        public CodeTableField NoField
        {
            get;
            internal set;
        }

        public TextTableField DescriptionField
        {
            get;
            internal set;
        }

        public TextTableField Description2Field
        {
            get;
            internal set;
        }

        public CodeTableField SearchDescriptionField
        {
            get;
            internal set;
        }

        public DateTableField LastDateModifiedField
        {
            get;
            internal set;
        }

        public DateTableField DateFilterField
        {
            get;
            internal set;
        }

        public CodeTableField NoSeriesField
        {
            get;
            internal set;
        }

		public Page CardPage
		{
			get;
			internal set;
		}

		public Page ListPage
		{
			get;
			internal set;
		}

		public Page StatisticsPage
		{
			get;
			internal set;
		}
	}
}
