namespace UncommonSense.CBreeze.Core.Generic
{
    /// <summary>
    /// Abstract base class for keyed items.
    /// </summary>
    /// <typeparam name="TKey">Type of key. Needs to be a struct.</typeparam>
    public abstract class KeyedItem<TKey>  where TKey : struct
    {
        public TKey ID
        {
            get;
            protected internal set;
        }
    }
}
