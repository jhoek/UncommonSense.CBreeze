using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UncommonSense.CBreeze.DomWriter;

namespace UncommonSense.CBreeze.DomWriter.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var project = new Project("NamespaceName");

            var @class = project.AddClass("ClassName");
            @class.Visibility = Visibility.Private;
            @class.Abstract = true;

            var constructor = @class.AddConstructor();
            constructor.Visibility = Visibility.Public;
            var parameter = constructor.AddParameter("ConstructorParam", "int");

            var classMethod = @class.AddMethod("ClassMethod", "int");
            classMethod.Abstract = true;
            classMethod.Lines.Add("// Foo;");

            var classProperty = @class.AddProperty("ClassProperty", "string");
            classProperty.GetterLines.Add("// Foo");
            classProperty.SetterLines.Add("// Foo");
            classProperty.Visibility = Visibility.Public;

            project.WriteTo(Console.Out);
        }
    }
}
