using System;
using System.Linq;
using System.Collections.Generic;

namespace CBreeze.NextGen
{
	public class Permissions : Dictionary<int, Permission>
	{
		public Permissions()
		{
		}

		public override string ToString()
		{
			var values = new List<string>();

			foreach (var permission in this)
			{
				var value = 
					string.Format(
						"{0}={1}{2}{3}{4}", 
						permission.Key,
						permission.Value.Read ? "r" : "",
						permission.Value.Insert ? "i" : "",
						permission.Value.Modify ? "m" : "",
						permission.Value.Delete ? "d" : "" 
					);

				values.Add(value);
			}

			return string.Join(",", values);
		}
	}
}

