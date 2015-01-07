using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Render
{
	public class DocumentEntityTypeManifest : RenderingManifest
	{
		internal DocumentEntityTypeManifest()
		{
		}

		public Table HeaderTable
		{
			get;
			internal set;
		}

		public OptionTableField HeaderTableDocumentTypeField
		{
			get;
			internal set;
		}

		public CodeTableField HeaderTableNoField
		{
			get;
			internal set;
		}

		public TableKey HeaderTablePrimaryKey
		{
			get;
			internal set;
		}

		public Table LineTable
		{
			get;
			internal set;
		}

		public OptionTableField LineTableDocumentTypeField
		{
			get;
			internal set;
		}

		public CodeTableField LineTableDocumentNoField
		{
			get;
			internal set;
		}

		public IntegerTableField LineTableLineNoField
		{
			get;
			internal set;
		}

		public TableKey LineTablePrimaryKey
		{
			get;
			internal set;
		}
	}
}
