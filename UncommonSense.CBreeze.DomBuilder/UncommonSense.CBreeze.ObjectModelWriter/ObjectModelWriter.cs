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

            foreach (var properties in objectModel.Elements.OfType<Properties>())
            {
                compilationUnits.Add(properties.ToCompilationUnit());
            }

			foreach (var container in objectModel.Elements.OfType<Container>())
			{
				compilationUnits.Add(container.ToCompilationUnit());
			}

            foreach (var enumeration in objectModel.Elements.OfType<Enumeration>())
            {
                compilationUnits.Add(enumeration.ToCompilationUnit());
            }

			return compilationUnits.ToArray();
		}

		public static CompilationUnit ToCompilationUnit(this Item item)
		{
			var @class = new Class(Visibility.Public, item.Name, item.BaseTypeName);

            // FIXME: Make ctor initializer

			var constructor = new Constructor(Visibility.Public, @class.Name, null, new CodeBlock());
            foreach (var attribute in item.AllAttributes.OfType<IdentifierAttribute>())
            {
                constructor.Parameters.Add(new FixedParameter(attribute.ParameterName, attribute.TypeName));
            }

            foreach (var attribute in item.InheritedAttributes.OfType<IdentifierAttribute>())
            {
                // FIXME: constructor.Initializer.Arguments.Add(new 
            }

            foreach (var attribute in item.Attributes.OfType<IdentifierAttribute>())
            {
                constructor.CodeBlock.Statements.AddFormat("{0} = {1};", attribute.Name, attribute.ParameterName);
            }

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
                            (attribute is IdentifierAttribute) ? AccessorVisibility.Internal : AccessorVisibility.Unspecified,
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

        public static CompilationUnit ToCompilationUnit(this Properties properties)
        {
            var @class = new Class(Visibility.Public, properties.Name, "Properties");

            return new CompilationUnit(new Namespace(properties.ObjectModel.Namespace, @class));
        }

		public static CompilationUnit ToCompilationUnit(this Container container)
		{
			var @class = new Class(Visibility.Public, container.Name, string.Format("Container<int,{0}>", container.ItemTypeName));

            var constructor = new Constructor(
                Visibility.Internal,
                container.Name,
                new ConstructorBaseInitializer(new ExpressionArgument("parentNode")),
                new CodeBlock(),
                new FixedParameter("parentNode", "Node"));
            @class.Constructors.Add(constructor);

            var toStringMethod = new Method(
                Visibility.Public,
                "ToString",
                "string",
                new CodeBlock(string.Format("return \"{0}\";", container.Name)));
            toStringMethod.Overriding = Overriding.Override;
            @class.Methods.Add(toStringMethod);

            return new CompilationUnit(new Namespace(container.ObjectModel.Namespace, @class));
		}

        public static CompilationUnit ToCompilationUnit(this Enumeration enumeration)
        {
            var @enum = 
                new UncommonSense.CSharp.Enum(
                    Visibility.Public, 
                    enumeration.Name, 
                    IntegralType.None, 
                    enumeration.Values.Select(v=>new EnumValue(v)).ToArray()
                );
            return new CompilationUnit(new Namespace(enumeration.ObjectModel.Namespace, @enum));
        }
	}
}

