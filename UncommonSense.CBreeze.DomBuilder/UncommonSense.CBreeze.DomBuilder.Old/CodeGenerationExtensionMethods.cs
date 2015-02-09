using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.DomWriter;

namespace UncommonSense.CBreeze.DomBuilder
{
	public static class CodeGenerationExtensionMethods
	{
		public static Project AsProject(this Dom dom)
		{
			var project = new Project(dom.Namespace);

			foreach (var item in dom.Nodes.OfType<Item>())
			{
				item.AddToProject(project);
			}

			foreach (var container in dom.Nodes.OfType<Container>())
			{
				container.AddToProject(project);
			}



			//foreach (var propertyCollection in dom.PropertyCollections)
			//{
			//    propertyCollection.AddToProject(project);
			//}

			AddINodeToProject(project);
			AddIKeyedValueToProject(project);
			AddContainerBaseClassToProject(project);

			return project;
		}

		public static Project AsProject(this Item item)
		{
			var project = new Project(item.Dom.Namespace);
			item.AddToProject(project);
			return project;
		}

		public static Project AsProject(this Container container)
		{
			var project = new Project(container.Dom.Namespace);
			container.AddToProject(project);
			return project;
		}

		//public static Project AsProject(this PropertyCollection propertyCollection)
		//{
		//    var project = new Project(propertyCollection.Dom.Namespace);
		//    propertyCollection.AddToProject(project);
		//    return project;
		//}

		public static void AddINodeToProject(Project project)
		{
			var @interface = project.Interfaces.Add(new Interface("INode"));
			var getChildNodesProperty = @interface.Properties.Add(new InterfaceProperty("ChildNodes", "IEnumerable<INode>"));
			getChildNodesProperty.HasGetter = true;
		}

		public static void AddIKeyedValueToProject(Project project)
		{
			var @interface = project.Interfaces.Add(new Interface("IKeyedValue<T>"));
			var getKeyMethod = @interface.Methods.Add(new InterfaceMethod("GetKey", "T"));
		}

		public static void AddContainerBaseClassToProject(Project project)
		{
			project.Imports.Add("System");
			project.Imports.Add("System.Collections.Generic");

			// Class declaration
			var @class = project.Classes.Add(new Class("Container<TKey, TValue>"));
			@class.Abstract = true;
			@class.BaseTypesNames.Add("INode");
			@class.BaseTypesNames.Add("IEnumerable<TValue>");
			@class.Constraints.Add("TValue", "INode, IKeyedValue<TKey>, IEquatable<TValue>");

			// Fields
			var innerDictionary = @class.Fields.Add(new Field("innerDictionary", "Dictionary<TKey, TValue>"));
			innerDictionary.Initialization = "new Dictionary<TKey, TValue>()";

			// ToString()
			@class.AddToStringMethod("Container");

			// TValue Add(TValue item)
			var addMethod = @class.Methods.Add(new ClassMethod("Add", "TValue"));
			addMethod.Parameters.Add(new MethodParameter("item", "TValue"));
			addMethod.Lines.Add("if (innerDictionary.ContainsValue(item))");
			addMethod.Lines.Add("\tthrow new ArgumentException(\"Item already exists.\");");
			addMethod.Lines.Add("");
			addMethod.Lines.Add("innerDictionary.Add(item.GetKey(), item);");
			addMethod.Lines.Add("");
			addMethod.Lines.Add("return item;");

			// bool Remove(TKey key)
			var removeMethod = @class.Methods.Add(new ClassMethod("Remove", "bool"));
			removeMethod.Parameters.Add(new MethodParameter("key", "TKey"));
			removeMethod.Lines.Add("return innerDictionary.Remove(key);");

			// void Clear()
			var clearMethod = @class.Methods.Add(new ClassMethod("Clear", "void"));
			clearMethod.Lines.Add("innerDictionary.Clear();");

			// bool ContainsKey(TKey key)
			var containsKeyMethod = @class.Methods.Add(new ClassMethod("ContainsKey", "bool"));
			containsKeyMethod.Parameters.Add(new MethodParameter("key", "TKey"));
			containsKeyMethod.Lines.Add("return innerDictionary.ContainsKey(key);");

			// bool ContainsValue(TValue value)
			var containsValueMethod = @class.Methods.Add(new ClassMethod("ContainsValue", "bool"));
			containsValueMethod.Parameters.Add(new MethodParameter("value", "TValue"));
			containsValueMethod.Lines.Add("return innerDictionary.ContainsValue(value);");

			// TValue this[TKey key]
			var indexerProperty = @class.Properties.Add(new IndexerClassProperty("TValue", "key", "TKey"));
			indexerProperty.GetterLines.Add("return innerDictionary[key];");

			// IEnumerable<INode> ChildNodes
			var childNodesProperty = @class.Properties.Add(new ClassProperty("ChildNodes", "IEnumerable<INode>"));
			childNodesProperty.GetterLines.Add("foreach(var keyValuePair in innerDictionary)");
			childNodesProperty.GetterLines.Add("{");
			childNodesProperty.GetterLines.Add("\tyield return keyValuePair.Value;");
			childNodesProperty.GetterLines.Add("}");

			// IEnumerator<TValue> GetEnumerator()
			var genericGetEnumeratorMethod = @class.Methods.Add(new ClassMethod("GetEnumerator", "IEnumerator<TValue>"));
			genericGetEnumeratorMethod.Lines.Add("return innerDictionary.Values.GetEnumerator();");

			// System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
			var getEnumeratorMethod = @class.Methods.Add(new ClassMethod("System.Collections.IEnumerable.GetEnumerator", "System.Collections.IEnumerator"));
			getEnumeratorMethod.Visibility = Visibility.None;
			getEnumeratorMethod.Lines.Add("return innerDictionary.Values.GetEnumerator();");
		}

		public static void AddToProject(this Item item, Project project)
		{
			project.Imports.Add("System.Collections.Generic");

			var @class = project.Classes.Add(new Class(item.Name));

			if (!string.IsNullOrEmpty(item.BaseItemName)) @class.BaseTypesNames.Add(item.BaseItemName);

			@class.BaseTypesNames.Add("INode");
			@class.AddIKeyedValueImplementation(item);
			@class.AddIEquatableImplementation(item);
			@class.AddAttributes(item);
			@class.AddToStringMethod(item.Name);

			// Type property
			if (item.Abstract)
			{
				@class.Abstract = true;

				var enumeration = project.Enumerations.Add(new Enumeration(string.Format("{0}Type", item.Name)));

				foreach (var derivedItem in item.Dom.Nodes.OfType<Item>().Where(i => i.BaseItemName == item.Name))
				{
					enumeration.Values.Add(derivedItem.Name, 0);
				}

				var typeProperty = @class.Properties.Add(new ClassProperty("Type", enumeration.Name));
				typeProperty.Abstract = true;
				typeProperty.HasGetter = true;
			}
			else
			{
				if (!string.IsNullOrEmpty(item.BaseItemName))
				{
					var enumerationName = string.Format("{0}Type", item.BaseItemName);
					var typeProperty = @class.Properties.Add(new ClassProperty("Type", enumerationName));
					typeProperty.Override = true;
					typeProperty.GetterLines.Add(string.Format("return {0}.{1};", enumerationName, item.Name));
				}
			}

			// ChildNodes property
			if (!item.Abstract)
			{
				var childNodesProperty = @class.Properties.Add(new ClassProperty("ChildNodes", "IEnumerable<INode>"));
				childNodesProperty.Override = (!string.IsNullOrEmpty(item.BaseItemName));
				if (item.ChildNodes.Any())
				{
					foreach (var childNode in item.ChildNodes)
					{
						childNodesProperty.GetterLines.Add(string.Format("yield return {0};", childNode.Name));
					}
				}
				else
				{
					childNodesProperty.GetterLines.Add("yield break;");
				}
			}
			else
			{
				var childNodesProperty = @class.Properties.Add(new ClassProperty("ChildNodes", "IEnumerable<INode>"));
				childNodesProperty.Abstract = true;
				childNodesProperty.HasGetter = true;
			}

			if (item.AutoCreateContainer)
			{
				var container = new Container(item.Name);
				container.AddToProject(project);
			}

			if (item.Properties.Any())
			{
				var propertyCollectionClass = project.Classes.Add(new Class(string.Format("{0}Properties", item.Name)));
				propertyCollectionClass.BaseTypesNames.Add("INode");

				var childNodesProperty = propertyCollectionClass.Properties.Add(new ClassProperty("ChildNodes", "IEnumerable<INode>"));

				foreach (var property in item.Properties)
				{
					var field = propertyCollectionClass.Fields.Add(new Field(property.FieldName, property.TypeName));
					if (property is ReferencePropertyType) field.Initialization = string.Format("new {0}()", property.TypeName);

					childNodesProperty.GetterLines.Add(string.Format("yield return {0};", property.FieldName));
				}
			}
		}

		public static void AddToProject(this Container container, Project project)
		{
			var @class = project.Classes.Add(new Class(container.Name));
			@class.BaseTypesNames.Add(string.Format("Container<int, {0}>", container.ItemTypeName));
			@class.AddToStringMethod(container.Name);
		}

		//public static void AddToProject(this PropertyCollection propertyCollection, Project project)
		//{
		//    var @class = project.Classes.Add(new Class(propertyCollection.Name));
		//    @class.BaseTypesNames.Add("INode");

		//    foreach (var property in propertyCollection.Properties)
		//    {
		//        var field = @class.Fields.Add(new Field(property.FieldName, property.TypeName));
		//    }

		//    // ChildNodes property
		//    var childNodesProperty = @class.Properties.Add(new ClassProperty("ChildNodes", "IEnumerable<INode>"));
		//    if (propertyCollection.Properties.Any())
		//    {
		//        foreach (var childNode in propertyCollection.Properties)
		//        {
		//            childNodesProperty.GetterLines.Add(string.Format("yield return {0};", childNode.Name));
		//        }
		//    }
		//    else
		//    {
		//        childNodesProperty.GetterLines.Add("yield break;");
		//    }

		//    @class.AddToStringMethod(propertyCollection.Name);
		//    // FIXME
		//}

		private static void AddAttributes(this Class @class, Item item)
		{
			foreach (var attribute in item.Attributes.Concat(item.ChildNodes))
			{
				var field = @class.Fields.Add(new Field(attribute.FieldName, attribute.TypeName));
				var property = @class.Properties.Add(new ClassProperty(attribute.Name, attribute.TypeName));
				property.GetterLines.Add(string.Format("return this.{0};", attribute.FieldName));
			}
		}

		private static void AddIEquatableImplementation(this Class @class, Item item)
		{
			if (item.UniqueAttributeNames.Any())
			{
				@class.BaseTypesNames.Add(string.Format("IEquatable<{0}>", item.Name));

				var equalsMethod = @class.Methods.Add(new ClassMethod("Equals", "bool"));
				equalsMethod.Parameters.Add(new MethodParameter("other", item.Name));
				equalsMethod.Lines.Add("if (other == null)");
				equalsMethod.Lines.Add("\treturn false;");
				equalsMethod.Lines.Add("");

				foreach (var uniqueAttributeName in item.UniqueAttributeNames)
				{
					equalsMethod.Lines.Add(string.Format("if (other.{0} == {0})", uniqueAttributeName));
					equalsMethod.Lines.Add("\treturn true;");
					equalsMethod.Lines.Add("");
				}

				equalsMethod.Lines.Add("return false;");
			}
		}

		private static void AddIKeyedValueImplementation(this Class @class, Item item)
		{
			if (!string.IsNullOrEmpty(item.KeyAttributeName))
			{
				var keyAttribute = item.AllAttributes.First(a => a.Name == item.KeyAttributeName);
				@class.BaseTypesNames.Add(string.Format("IKeyedValue<{0}>", keyAttribute.TypeName));

				var getKeyMethod = @class.Methods.Add(new ClassMethod("GetKey", keyAttribute.TypeName));
				getKeyMethod.Lines.Add(string.Format("return {0};", keyAttribute.Name));
			}
		}

		private static void AddToStringMethod(this Class @class, string returnValue)
		{
			var toStringMethod = @class.Methods.Add(new ClassMethod("ToString", "string"));
			toStringMethod.Override = true;
			toStringMethod.Lines.Add(string.Format("return \"{0}\";", returnValue));
		}
	}
}
