#r UncommonSense.CBreeze.Core.dll
#r UncommonSense.CBreeze.Emit.dll

using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Emit;

var application = new Application();

var table = application.Tables.Add(50000, "Sample Table");
table.Fields.AddCodeTableField(1, "Code", null);
table.Fields.AddIntegerTableField(2, "Integer");
table.Fields.AddTextTableField(3, "Text", null);
table.Fields.AddOptionTableField(4, "Option");

foreach(var field in table.Fields)
{
  var captionMLProperty = (field.GetPropertyByName("CaptionML") as MultiLanguageProperty);

  if (captionMLProperty != null)
  {
    captionMLProperty.Value.Add(1033, field.Name);
  }    
}

var csideWriter = new CSideWriter(Console.Out);
application.Write(csideWriter);

