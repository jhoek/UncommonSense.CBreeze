using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Write
{
	public static class ObjectsWriter
	{
		public static void Write(this Tables tables, CSideWriter writer)
		{
			foreach (var table in tables.OrderBy(t=>t.ID))
			{
				table.Write(writer);
			}
		}

		public static void Write(this Pages pages, CSideWriter writer)
		{
			foreach (var page in pages.OrderBy(p=>p.ID))
			{
				page.Write(writer);
			}
		}

		public static void Write(this Reports reports, CSideWriter writer)
		{
			foreach (var report in reports.OrderBy(r=>r.ID))
			{
				report.Write(writer);
			}
		}

		public static void Write(this Codeunits codeunits, CSideWriter writer)
		{
			foreach (var codeunit in codeunits.OrderBy(c=>c.ID))
			{
				codeunit.Write(writer);
			}
		}

		public static void Write(this Queries queries, CSideWriter writer)
		{
			foreach (var query in queries.OrderBy(q=>q.ID))
			{
				query.Write(writer);
			}
		}

		public static void Write(this XmlPorts xmlPorts, CSideWriter writer)
		{
			foreach (var xmlPort in xmlPorts.OrderBy(x=>x.ID))
			{
				xmlPort.Write(writer);
			}
		}

		public static void Write(this MenuSuites menuSuites, CSideWriter writer)
		{
			foreach (var menuSuite in menuSuites.OrderBy(m=>m.ID))
			{
				menuSuite.Write(writer);
			}
		}

        public static string GetObjectSignature(this UncommonSense.CBreeze.Core.Object @object)
        {
            return string.Format("OBJECT {0} {1} {2}", @object.Type.AsString(), @object.ID, @object.Name);
        }

        public static string AsString(this ObjectType objectType)
        {
            switch (objectType)
            {
                case ObjectType.XmlPort:
                    return "XMLport";
                default:
                    return objectType.ToString();
            }
        }
	}
}
