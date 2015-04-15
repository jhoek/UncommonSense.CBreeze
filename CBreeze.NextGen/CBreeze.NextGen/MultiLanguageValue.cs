using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBreeze.NextGen
{
	public class MultiLanguageValue : Dictionary<string, string>
	{
		public override string ToString()
		{
			return string.Join(";", this.Select(p => string.Format("{0}={1}", p.Key, p.Value)));
		}
	}
}
