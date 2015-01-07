#r UncommonSense.CBreeze.Core.dll
#r UncommonSense.CBreeze.Emit.dll

using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Emit;

var application = new Application();

var table = application.Tables.Add(50000, "Customer Group");
table.Properties.PasteIsValid = true;

var field = table.Fields.AddCodeTableField(1, "Code", null);
field.Properties.NotBlank = true;
field.Properties.CaptionML.Add(1033, field.Name);
field.Properties.OnValidate.CodeLines.Add("// Hello, world!");

var csideWriter = new CSideWriter(Console.Out);

application.Write(csideWriter);