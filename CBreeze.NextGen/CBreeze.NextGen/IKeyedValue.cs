using System;

namespace CBreeze.NextGen
{
	public interface IKeyedValue<T>
	{
		T GetKey();
	}
}

