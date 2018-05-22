using System;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Core.MenuSuite;

namespace UncommonSense.CBreeze.Write
{
	public static class MenuSuiteNodesWriter
	{
		public static void Write(this MenuSuiteNodes nodes, CSideWriter writer)
		{
			writer.BeginSection("MENUNODES");

			foreach (var node in nodes) 
			{
				node.Write(writer);
			}

			writer.EndSection();
		}
	}
}

