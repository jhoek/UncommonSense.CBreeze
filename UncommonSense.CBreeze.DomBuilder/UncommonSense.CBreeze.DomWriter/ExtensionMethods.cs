using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.DomWriter
{
    public static class ExtensionMethods
    {
        // TODO: Convenience methods for every member of type List in Project
        public static Class AddClass(this Project project, string name)
        {
            var @class = new Class(name);
            project.Classes.Add(@class);
            return @class;
        }

        // TODO: Convenience methods for every member of type list in Class
        public static Field AddField(this Class @class, string name, string typeName)
        {
            var field = new Field(name, typeName);
            @class.Fields.Add(field);
            return field;
        }

        public static Constructor AddConstructor(this Class @class)
        {
            var constructor = new Constructor();
            @class.Constructors.Add(constructor);
            return constructor;
        }

        public static ClassMethod AddMethod(this Class @class, string name, string returnTypeName)
        {
            var method = new ClassMethod(name, returnTypeName);
            @class.Methods.Add(method);
            return method;
        }

        public static Property AddProperty(this Class @class, string name, string typeName)
        {
            var property = new ClassProperty(name, typeName);
            @class.Properties.Add(property);
            return property;
        }

        // TODO: Convenience methods for every member of type List in Method (and its derived classes)
        public static MethodParameter AddParameter(this Method method, string name, string typeName)
        {
            var methodParameter = new MethodParameter(name, typeName);
            method.Parameters.Add(methodParameter);
            return methodParameter;
        }

        public static void WriteTo(this Project project, string fileName)
        {
            using (var streamWriter = new StreamWriter(fileName, false))
            {
                project.WriteTo(streamWriter);
            }
        }

        public static void WriteTo(this Project project, TextWriter writer)
        {
            using (var indentedTextWriter = new IndentedTextWriter(writer))
            {
                project.WriteTo(indentedTextWriter);
            }
        }

        private static void WriteTo(this Project project, IndentedTextWriter writer)
        {
            writer.WriteLine("namespace {0}", project.Namespace);
            writer.BeginBlock();

            foreach (var import in project.Imports.Distinct())
            {
                writer.WriteLine("using {0};", import);
            }

            if (project.Imports.Any())
                writer.WriteLine();

            foreach (var @interface in project.Interfaces)
            {
                @interface.WriteTo(writer);

                if (@interface != project.Interfaces.Last() || project.Enumerations.Any() || project.Classes.Any())
                    writer.WriteLine();
            }

            foreach (var enumeration in project.Enumerations)
            {
                enumeration.WriteTo(writer);

                if (enumeration != project.Enumerations.Last() || project.Classes.Any())
                    writer.WriteLine();
            }

            foreach (var @class in project.Classes)
            {
                @class.WriteTo(writer);

                if (@class != project.Classes.Last())
                    writer.WriteLine();
            }

            writer.EndBlock();
        }

        private static void WriteTo(this Enumeration enumeration, IndentedTextWriter writer)
        {
            enumeration.Visibility.WriteTo(writer);
            writer.WriteLine("enum {0}", enumeration.Name);
            writer.BeginBlock();

            var printNumericValues = enumeration.Values.Values.Any(v => v != 0);

            foreach (var value in enumeration.Values)
            {
                if (printNumericValues)
                    writer.WriteLine("{0} = {1},", value.Key, value.Value);
                else
                    writer.WriteLine("{0},", value.Key);
            }

            writer.EndBlock();
        }

        private static void WriteTo(this Interface @interface, IndentedTextWriter writer)
        {
            @interface.Visibility.WriteTo(writer);
            writer.WriteLine("interface {0}", @interface.Name);

            writer.BeginBlock();

            foreach (var method in @interface.Methods)
            {
                method.WriteTo(writer);

                if (method != @interface.Methods.Last() || @interface.Properties.Any())
                    writer.WriteLine();
            }

            foreach (var property in @interface.Properties)
            {
                property.WriteTo(writer);

                if (property != @interface.Properties.Last())
                    writer.WriteLine();
            }

            writer.EndBlock();
        }

        private static void WriteTo(this InterfaceMethod interfaceMethod, IndentedTextWriter writer)
        {
            writer.WriteLine("{0} {1}();", interfaceMethod.ReturnTypeName, interfaceMethod.Name);
        }

        private static void WriteTo(this InterfaceProperty interfaceProperty, IndentedTextWriter writer)
        {
            writer.WriteLine("{0} {1}", interfaceProperty.TypeName, interfaceProperty.Name);
            writer.BeginBlock();
            if (interfaceProperty.HasGetter)
                writer.WriteLine("get;");
            if (interfaceProperty.HasSetter)
                writer.WriteLine("set;");
            writer.EndBlock();
        }

        private static void WriteTo(this Class @class, IndentedTextWriter writer)
        {
            @class.Visibility.WriteTo(writer);

            if (@class.Abstract)
                writer.Write("abstract ");

            writer.Write("class {0}", @class.Name);

            if (@class.BaseTypesNames.Any())
            {
                writer.Write(" : ");
                writer.Write(string.Join(", ", @class.BaseTypesNames));
            }

            foreach (var constraint in @class.Constraints)
            {
                writer.Write(" where {0} : {1}", constraint.Key, constraint.Value);
            }

            writer.WriteLine();
            writer.BeginBlock();

            foreach (var field in @class.Fields)
            {
                field.WriteTo(writer);
            }

            if (@class.Fields.Any())
                writer.WriteLine();

            foreach (var constructor in @class.Constructors)
            {
                constructor.WriteTo(writer);
            }

            foreach (var method in @class.Methods)
            {
                method.WriteTo(writer);

                if (method != @class.Methods.Last() || @class.Properties.Any())
                    writer.WriteLine();
            }

            foreach (var property in @class.Properties)
            {
                property.WriteTo(writer);

                if (property != @class.Properties.Last())
                    writer.WriteLine();
            }

            writer.EndBlock();
        }

        private static void WriteTo(this Field field, IndentedTextWriter writer)
        {
            field.Visibility.WriteTo(writer);
            writer.Write("{0} {1}", field.TypeName, field.Name);

            if (!string.IsNullOrEmpty(field.Initialization))
                writer.Write(" = {0}", field.Initialization);

            writer.WriteLine(";");
        }

        private static void WriteTo(this Constructor constructor, IndentedTextWriter writer)
        {
        }

        private static void WriteTo(this ClassMethod classMethod, IndentedTextWriter writer)
        {
            classMethod.Visibility.WriteTo(writer);

            if (classMethod.Abstract)
                writer.Write("abstract ");

            if (classMethod.Override)
                writer.Write("override ");

            writer.WriteLine("{0} {1}({2})", classMethod.ReturnTypeName, classMethod.Name, string.Join(",", classMethod.Parameters.Select(p => p.ToString())));
            writer.BeginBlock();

            foreach (var line in classMethod.Lines)
            {
                writer.WriteLine(line);
            }

            writer.EndBlock();
        }

        private static void WriteTo(this ClassProperty classProperty, IndentedTextWriter writer)
        {
            classProperty.Visibility.WriteTo(writer);

            if (classProperty.Abstract)
                writer.Write("abstract ");

            if (classProperty.Override)
                writer.Write("override ");

            writer.Write("{0} {1}", classProperty.TypeName, classProperty.Name);

            if (classProperty is IndexerClassProperty)
            {
                var indexerClassProperty = classProperty as IndexerClassProperty;
                writer.Write("[{0} {1}]", indexerClassProperty.IndexerTypeName, indexerClassProperty.IndexerName);
            }

            writer.WriteLine();
            writer.BeginBlock();

            if (classProperty.Abstract)
            {
                if (classProperty.HasGetter)
                {
                    writer.WriteLine("get;");
                }
            }
            else
            {
                if (classProperty.GetterLines.Any())
                {
                    writer.WriteLine("get");
                    writer.BeginBlock();
                    foreach (var line in classProperty.GetterLines)
                    {
                        writer.WriteLine(line);
                    }
                    writer.EndBlock();
                }
            }

            if (classProperty.Abstract)
            {
                if (classProperty.HasSetter)
                {
                    writer.WriteLine("set;");
                }
            }
            else
            {
                if (classProperty.SetterLines.Any())
                {
                    writer.WriteLine("set");
                    writer.BeginBlock();
                    foreach (var line in classProperty.SetterLines)
                    {
                        writer.WriteLine(line);
                    }
                    writer.EndBlock();
                }
            }

            writer.EndBlock();
        }

        private static void WriteTo(this Visibility visibility, IndentedTextWriter writer)
        {
            switch (visibility)
            {
                case Visibility.Public:
                    writer.Write("public ");
                    break;
                case Visibility.Internal:
                    writer.Write("internal ");
                    break;
                case Visibility.Private:
                    writer.Write("private ");
                    break;
            }
        }

        private static void BeginBlock(this IndentedTextWriter writer)
        {
            writer.WriteLine("{");
            writer.Indent++;
        }

        private static void EndBlock(this IndentedTextWriter writer)
        {
            writer.Indent--;
            writer.WriteLine("}");
        }
    }
}
