# Using the parser from .NET 

To create a listener, either implement the `IListener` interface in one of your classes, or derive your listener class from the `ListenerBase` class. In the latter case, your class will only need to override the methods it is interested in. If you'd prefer to receive events for each object and subobject found, you could also use the `EventEmitterListener` and subscribe to its events.

```csharp
public class MyListener : ListenerBase
{
    // override relevant methods
}
```

A parser instance is created by calling the (parameterless) constructor. After that, you set the parser's `Listener` property to your listener instance:

```csharp
var myListener = new MyListener();

var parser = new Parser();
parser.Listener = myListener;
```

The parser accepts input either from an `IEnumerable<string>` containing the file names to parse, or from an `IEnumerable<sting>` containing the text lines to parse: 

``` csharp
parser.ParseFiles(myFiles); // myFiles could e.g. be the output of Directory.GetFiles()

// or 

parser.ParseLines(myLines);
``` 