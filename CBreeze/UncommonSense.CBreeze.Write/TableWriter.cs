using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Core.Table;

namespace UncommonSense.CBreeze.Write
{
	public static class TableWriter
	{
		public static void Write(this Table table, CSideWriter writer)
		{
			writer.BeginSection(table.GetObjectSignature());
			table.ObjectProperties.Write(writer);
			table.Properties.Write(writer);
			table.Fields.Write(writer);
			table.Keys.Write(writer);
			table.FieldGroups.Write(writer);
			table.Code.Write(writer);
			writer.EndSection();
            writer.InnerWriter.WriteLine();
		}
	}
}
