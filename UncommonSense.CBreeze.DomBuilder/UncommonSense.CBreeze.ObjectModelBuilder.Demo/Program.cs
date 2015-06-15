namespace UncommonSense.CBreeze.ObjectModelBuilder.Demo
{
    class MainClass
    {
        private const string @namespace = "UncommonSense.CBreeze.70.Core";
        private static ObjectModel objectModel = new ObjectModel(@namespace);

        public static void Main(string[] args)
        {
            AddItems();
        }

        static void AddItems()
        {
            AddItem("Application");
            AddItem("Object");
            AddItem("Table");
        }

        public static Item AddItem(string name)
        {
            var item = new Item(name);
            objectModel.Elements.Add(item);
            return item;
        }
    }
}
