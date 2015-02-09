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
            var classMethod = @class.AddMethod("ClassMethod", "int");

            @class.Visibility = Visibility.Private;
            @class.Abstract = true;           

            classMethod.Abstract = true;
            classMethod.Lines.Add("// Foo;");



            project.WriteTo(Console.Out);
        }
    }
}
