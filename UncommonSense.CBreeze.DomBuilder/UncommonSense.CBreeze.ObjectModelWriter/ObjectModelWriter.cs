using System;
using UncommonSense.CBreeze.ObjectModelBuilder;
using System.Linq;
using UncommonSense.CSharp;
using System.IO;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.ObjectModelWriter
{
	public static class ObjectModelWriter
	{
		public static CompilationUnit[] ToCompilationUnits(this ObjectModel objectModel)
		{
			var compilationUnits = new List<CompilationUnit>();

			foreach (var item in objectModel.Elements.OfType<Item>())
			{
				compilationUnits.Add(item.ToCompilationUnit());	
			}

			foreach (var container in objectModel.Elements.OfType<Container>())
			{
				compilationUnits.Add(container.ToCompilationUnit());
			}

			return compilationUnits.ToArray();
		}

		public static CompilationUnit ToCompilationUnit(this Item item)
		{
			var @class = new Class(Visibility.Public, item.Name, item.BaseTypeName);

			var constructor = new Constructor(Visibility.Public, @class.Name, null, new CodeBlock());
			@class.Constructors.Add(constructor);

            foreach (var attribute in item.Attributes.OfType<ValueAttribute>())
            {
                @class.Properties.Add(
                    new UncommonSense.CSharp.Property(
                        Visibility.Public,
                        attribute.Name,
                        attribute.TypeName,
                        new PropertyAccessor(
                            AccessorVisibility.Unspecified,
                            null
                        ),
                        new PropertyAccessor(
                            AccessorVisibility.Unspecified,
                            null
                        )
                    )
                );
            }

			foreach (var attribute in item.Attributes.OfType<ReferenceAttribute>())
			{
				@class.Properties.Add(
					new UncommonSense.CSharp.Property(
						Visibility.Public,
						attribute.Name,
						attribute.TypeName,
						new PropertyAccessor(
							AccessorVisibility.Unspecified,
							null
						),
						new PropertyAccessor(
							AccessorVisibility.Internal,
							null
                        )
					)
				);

				constructor.CodeBlock.Statements.AddFormat("{0} = new {1}(this);", attribute.Name, attribute.TypeName);
			}

			return new CompilationUnit(new Namespace(item.ObjectModel.Namespace, @class));
		}

		public static CompilationUnit ToCompilationUnit(this Container container)
		{
			var @class = new Class(Visibility.Public, container.Name, string.Format("Container<int,{0}>", container.ItemTypeName));

            var constructor = new Constructor(
                Visibility.Public,
                container.Name,
                null,
                new CodeBlock());
            @class.Constructors.Add(constructor);

            var toStringMethod = new Method(
                Visibility.Public,
                "ToString",
                "string",
                new CodeBlock(string.Format("return \"{0}\";", container.Name)));
            @class.Methods.Add(toStringMethod);
            /*
	{
		internal Tables(Node parentNode) : base(parentNode)
		{
		}
	}

             */

            return new CompilationUnit(new Namespace(container.ObjectModel.Namespace, @class));
		}
	}
}

