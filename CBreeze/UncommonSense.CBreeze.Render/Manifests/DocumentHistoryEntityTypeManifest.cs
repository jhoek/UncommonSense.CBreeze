using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Render
{
	public class DocumentHistoryEntityTypeManifest : RenderingManifest
	{
		internal DocumentHistoryEntityTypeManifest()
		{
		}

		public Table HeaderTable
		{
			get;
			internal set;
		}

		public Table LineTable
		{
			get;
			internal set;
		}
	}
}
