namespace UncommonSense.CBreeze.Core.Page.Control
{
    public class ControlList : Generic.Collection<string>
    {
        // Ctor made public to allow ControlListProperty to new up an instance
        public ControlList()
        {
        }

        public void AddRange(params string[] controlNames)
        {
            foreach (var item in controlNames)
            {
                Add(item);
            }
        }

        public void Set(string[] values)
        {
            Clear();
            AddRange(values ?? new string[] { });
        }
    }
}