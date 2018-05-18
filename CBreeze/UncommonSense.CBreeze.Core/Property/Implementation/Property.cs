namespace UncommonSense.CBreeze.Core.Property.Implementation
{
    public abstract class Property
    {
        internal Property(string name)
        {
            Name = name;
        }

        public abstract bool HasValue
        {
            get;
        }

        public string Name
        {
            get;
            private set;
        }

        /// <summary>
        /// Resets the property to its uninitialized value.
        /// </summary>
        public abstract void Reset();

        /// <summary>
        /// Returns an object containing the property value.
        /// For more type-safe operations, use the Value property instead
        /// </summary>
        /// <returns></returns>
        public abstract object GetValue();
    }
}