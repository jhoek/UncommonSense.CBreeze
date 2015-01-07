using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Render
{
	public class SetupEntityTypeManifest : RenderingManifest
	{
		internal SetupEntityTypeManifest()
		{
		}

		public Table Table
		{
			get;
			internal set;
		}

        public CodeTableField PrimaryKeyField
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

        public GroupPageControl PageGeneralGroupControl
        {
            get;
            internal set;
        }

        public GroupPageControl PageNumberingGroupControl
        {
            get;
            internal set;
        }
	}
}
