using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBreeze.NextGen
{
	public class IntegerVariable : Variable
	{
		public IntegerVariable(int uid, string name)
			: base(uid, name)
		{
		}

		public override VariableType Type
		{
			get
			{
				return VariableType.Integer;
			}
		}

		public override string ToString()
		{
			return string.Format("{0}{2}@{1} : Integer", Name, UID, Dimensions == null ? "" : string.Format("[{0}]", Dimensions));
		}
	}
}
