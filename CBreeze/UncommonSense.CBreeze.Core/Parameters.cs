using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class Parameters : IEnumerable<Parameter>
    {
        private Dictionary<Int32,Parameter> innerList = new Dictionary<Int32,Parameter>();

        internal Parameters()
        {
        }

        public ActionParameter AddActionParameter(Boolean var, Int32 id, String name)
        {
            ActionParameter item = new ActionParameter(var, id, name);
            innerList.Add(id, item);
            return item;
        }

        public AutomationParameter AddAutomationParameter(Boolean var, Int32 id, String name, String subType)
        {
            AutomationParameter item = new AutomationParameter(var, id, name, subType);
            innerList.Add(id, item);
            return item;
        }

        public BigIntegerParameter AddBigIntegerParameter(Boolean var, Int32 id, String name)
        {
            BigIntegerParameter item = new BigIntegerParameter(var, id, name);
            innerList.Add(id, item);
            return item;
        }

        public BigTextParameter AddBigTextParameter(Boolean var, Int32 id, String name)
        {
            BigTextParameter item = new BigTextParameter(var, id, name);
            innerList.Add(id, item);
            return item;
        }

        public BinaryParameter AddBinaryParameter(Boolean var, Int32 id, String name, Int32 dataLength = 100)
        {
            BinaryParameter item = new BinaryParameter(var, id, name, dataLength);
            innerList.Add(id, item);
            return item;
        }

        public BooleanParameter AddBooleanParameter(Boolean var, Int32 id, String name)
        {
            BooleanParameter item = new BooleanParameter(var, id, name);
            innerList.Add(id, item);
            return item;
        }

        public ByteParameter AddByteParameter(Boolean var, Int32 id, String name)
        {
            ByteParameter item = new ByteParameter(var, id, name);
            innerList.Add(id, item);
            return item;
        }

        public CharParameter AddCharParameter(Boolean var, Int32 id, String name)
        {
            CharParameter item = new CharParameter(var, id, name);
            innerList.Add(id, item);
            return item;
        }

        public CodeParameter AddCodeParameter(Boolean var, Int32 id, String name, Int32? dataLength = null)
        {
            CodeParameter item = new CodeParameter(var, id, name, dataLength);
            innerList.Add(id, item);
            return item;
        }

        public CodeunitParameter AddCodeunitParameter(Boolean var, Int32 id, String name, Int32 subType)
        {
            CodeunitParameter item = new CodeunitParameter(var, id, name, subType);
            innerList.Add(id, item);
            return item;
        }

        public DateFormulaParameter AddDateFormulaParameter(Boolean var, Int32 id, String name)
        {
            DateFormulaParameter item = new DateFormulaParameter(var, id, name);
            innerList.Add(id, item);
            return item;
        }

        public DateParameter AddDateParameter(Boolean var, Int32 id, String name)
        {
            DateParameter item = new DateParameter(var, id, name);
            innerList.Add(id, item);
            return item;
        }

        public DateTimeParameter AddDateTimeParameter(Boolean var, Int32 id, String name)
        {
            DateTimeParameter item = new DateTimeParameter(var, id, name);
            innerList.Add(id, item);
            return item;
        }

        public DecimalParameter AddDecimalParameter(Boolean var, Int32 id, String name)
        {
            DecimalParameter item = new DecimalParameter(var, id, name);
            innerList.Add(id, item);
            return item;
        }

        public DialogParameter AddDialogParameter(Boolean var, Int32 id, String name)
        {
            DialogParameter item = new DialogParameter(var, id, name);
            innerList.Add(id, item);
            return item;
        }

        public DotNetParameter AddDotNetParameter(Boolean var, Int32 id, String name, String subType)
        {
            DotNetParameter item = new DotNetParameter(var, id, name, subType);
            innerList.Add(id, item);
            return item;
        }

        public DurationParameter AddDurationParameter(Boolean var, Int32 id, String name)
        {
            DurationParameter item = new DurationParameter(var, id, name);
            innerList.Add(id, item);
            return item;
        }

        public ExecutionModeParameter AddExecutionModeParameter(Boolean var, Int32 id, String name)
        {
            ExecutionModeParameter item = new ExecutionModeParameter(var, id, name);
            innerList.Add(id, item);
            return item;
        }

        public FieldRefParameter AddFieldRefParameter(Boolean var, Int32 id, String name)
        {
            FieldRefParameter item = new FieldRefParameter(var, id, name);
            innerList.Add(id, item);
            return item;
        }

        public FileParameter AddFileParameter(Boolean var, Int32 id, String name)
        {
            FileParameter item = new FileParameter(var, id, name);
            innerList.Add(id, item);
            return item;
        }

        public GuidParameter AddGuidParameter(Boolean var, Int32 id, String name)
        {
            GuidParameter item = new GuidParameter(var, id, name);
            innerList.Add(id, item);
            return item;
        }

        public InStreamParameter AddInStreamParameter(Boolean var, Int32 id, String name)
        {
            InStreamParameter item = new InStreamParameter(var, id, name);
            innerList.Add(id, item);
            return item;
        }

        public IntegerParameter AddIntegerParameter(Boolean var, Int32 id, String name)
        {
            IntegerParameter item = new IntegerParameter(var, id, name);
            innerList.Add(id, item);
            return item;
        }

        public KeyRefParameter AddKeyRefParameter(Boolean var, Int32 id, String name)
        {
            KeyRefParameter item = new KeyRefParameter(var, id, name);
            innerList.Add(id, item);
            return item;
        }

        public OcxParameter AddOcxParameter(Boolean var, Int32 id, String name, String subType)
        {
            OcxParameter item = new OcxParameter(var, id, name, subType);
            innerList.Add(id, item);
            return item;
        }

        public OptionParameter AddOptionParameter(Boolean var, Int32 id, String name)
        {
            OptionParameter item = new OptionParameter(var, id, name);
            innerList.Add(id, item);
            return item;
        }

        public OutStreamParameter AddOutStreamParameter(Boolean var, Int32 id, String name)
        {
            OutStreamParameter item = new OutStreamParameter(var, id, name);
            innerList.Add(id, item);
            return item;
        }

        public PageParameter AddPageParameter(Boolean var, Int32 id, String name, Int32 subType)
        {
            PageParameter item = new PageParameter(var, id, name, subType);
            innerList.Add(id, item);
            return item;
        }

        public QueryParameter AddQueryParameter(Boolean var, Int32 id, String name, Int32 subType)
        {
            QueryParameter item = new QueryParameter(var, id, name, subType);
            innerList.Add(id, item);
            return item;
        }

        public RecordIDParameter AddRecordIDParameter(Boolean var, Int32 id, String name)
        {
            RecordIDParameter item = new RecordIDParameter(var, id, name);
            innerList.Add(id, item);
            return item;
        }

        public RecordParameter AddRecordParameter(Boolean var, Int32 id, String name, Int32 subType)
        {
            RecordParameter item = new RecordParameter(var, id, name, subType);
            innerList.Add(id, item);
            return item;
        }

        public RecordRefParameter AddRecordRefParameter(Boolean var, Int32 id, String name)
        {
            RecordRefParameter item = new RecordRefParameter(var, id, name);
            innerList.Add(id, item);
            return item;
        }

        public ReportParameter AddReportParameter(Boolean var, Int32 id, String name, Int32 subType)
        {
            ReportParameter item = new ReportParameter(var, id, name, subType);
            innerList.Add(id, item);
            return item;
        }

        public TestPageParameter AddTestPageParameter(Boolean var, Int32 id, String name, Int32 subType)
        {
            TestPageParameter item = new TestPageParameter(var, id, name, subType);
            innerList.Add(id, item);
            return item;
        }

        public TestRequestPageParameter AddTestRequestPageParameter(Boolean var, Int32 id, String name, Int32 subType)
        {
            TestRequestPageParameter item = new TestRequestPageParameter(var, id, name, subType);
            innerList.Add(id, item);
            return item;
        }

        public TextParameter AddTextParameter(Boolean var, Int32 id, String name, Int32? dataLength = null)
        {
            TextParameter item = new TextParameter(var, id, name, dataLength);
            innerList.Add(id, item);
            return item;
        }

        public TimeParameter AddTimeParameter(Boolean var, Int32 id, String name)
        {
            TimeParameter item = new TimeParameter(var, id, name);
            innerList.Add(id, item);
            return item;
        }

        public TransactionTypeParameter AddTransactionTypeParameter(Boolean var, Int32 id, String name)
        {
            TransactionTypeParameter item = new TransactionTypeParameter(var, id, name);
            innerList.Add(id, item);
            return item;
        }

        public VariantParameter AddVariantParameter(Boolean var, Int32 id, String name)
        {
            VariantParameter item = new VariantParameter(var, id, name);
            innerList.Add(id, item);
            return item;
        }

        public XmlPortParameter AddXmlPortParameter(Boolean var, Int32 id, String name, Int32 subType)
        {
            XmlPortParameter item = new XmlPortParameter(var, id, name, subType);
            innerList.Add(id, item);
            return item;
        }

        public bool Remove(Int32 id)
        {
            return innerList.Remove(id);
        }

        public IEnumerator<Parameter> GetEnumerator()
        {
            return innerList.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerList.Values.GetEnumerator();
        }
    }
}
