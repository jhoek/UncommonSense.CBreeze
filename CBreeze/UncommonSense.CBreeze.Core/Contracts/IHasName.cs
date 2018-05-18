namespace UncommonSense.CBreeze.Core.Contracts
{
	public interface IHasName
	{
		// This supports both elements that have a Name property (e.g. table fields),
		// and elements whose names are stored in their Properties (e.g. page controls).

		// Known issue: what if somebody later changes a page control's name to something that
		// already exists within the same PageControls collection?

		string GetName();
	}
}
