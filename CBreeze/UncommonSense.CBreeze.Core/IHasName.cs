using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.Core
{
	public interface IHasName
	{
		// This supports both elements that have a Name property (e.g. table fields),
		// and elements whose names are stored in their Properties (e.g. page controls).

		// FIXME: What if somebody later changes a page control's name to something that
		// already exists within the same PageControls collection?

		string GetName();
	}
}
