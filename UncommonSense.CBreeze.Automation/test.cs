using System.Management.Automation;

namespace Oink
{
    public class Foo
    {
        public ScriptBlock Baz { get; set; }

        public void Bar()
        {
            this.Baz.InvokeWithContext();
        }
    }
}