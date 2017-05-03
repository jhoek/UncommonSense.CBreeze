using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Parse.Demo
{
    public class MyListener : ListenerBase
    {
        private int noOfFiles;
        private int noOfObjects;

        public override void OnBeginFile(string fileName)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(fileName);
            Console.ResetColor();
            noOfFiles++;
        }

        public override void OnBeginObject(UncommonSense.CBreeze.Common.ObjectType objectType, int objectID, string objectName)
        {
            Console.WriteLine("\t{0} {1} {2}", objectType, objectID, objectName);
            noOfObjects++;
        }

        public override void OnFunctionAttribute(string name, params string[] values)
        {
            Console.WriteLine("\t\t{0}={1}", name, string.Join("$", values));
        }
        public override void OnBeginFunction(int functionID, string functionName, bool functionLocal)
        {
            Console.WriteLine("\t\tFunction {0}@{1}", functionName, functionID);
        }

        public override void OnEndApplication()
        {
            Console.WriteLine();
            Console.WriteLine("{0} object(s) read from {1} file(s).", noOfObjects, noOfFiles);
        }
    }
}
