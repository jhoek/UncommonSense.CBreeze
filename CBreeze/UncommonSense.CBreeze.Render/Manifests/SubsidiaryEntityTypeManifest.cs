using System;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Render
{
	public class SubsidiaryEntityTypeManifest : RenderingManifest
	{
		internal SubsidiaryEntityTypeManifest()
		{
		}

		public Table Table
		{
			get;
			internal set;
		}

        public IntegerTableField LineNoField
        {
            get;
            internal set;
        }

        public CodeTableField CodeField
        {
            get;
            internal set;
        }

        public TableKey PrimaryKey
        {
            get;
            internal set;
        }

		public Page Page
		{
			get;
			internal set;
		}

        public ContainerPageControl PageContentAreaControl
        {
            get;
            internal set;
        }

        public GroupPageControl PageRepeaterControl
        {
            get;
            internal set;
        }
	}
}

