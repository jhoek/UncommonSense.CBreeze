using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class Variables : IEnumerable<Variable>
    {
        private Dictionary<Int32,Variable> innerList = new Dictionary<Int32,Variable>();

        internal Variables()
        {
        }

        public ActionVariable AddActionVariable(Int32 id, String name)
        {
            ActionVariable item = new ActionVariable(id, name);
            innerList.Add(id, item);
            return item;
        }

        public AutomationVariable AddAutomationVariable(Int32 id, String name, String subType)
        {
            AutomationVariable item = new AutomationVariable(id, name, subType);
            innerList.Add(id, item);
            return item;
        }

        public BigIntegerVariable AddBigIntegerVariable(Int32 id, String name)
        {
            BigIntegerVariable item = new BigIntegerVariable(id, name);
            innerList.Add(id, item);
            return item;
        }

        public BigTextVariable AddBigTextVariable(Int32 id, String name)
        {
            BigTextVariable item = new BigTextVariable(id, name);
            innerList.Add(id, item);
            return item;
        }

        public BinaryVariable AddBinaryVariable(Int32 id, String name, Int32 dataLength = 100)
        {
            BinaryVariable item = new BinaryVariable(id, name, dataLength);
            innerList.Add(id, item);
            return item;
        }

        public BooleanVariable AddBooleanVariable(Int32 id, String name)
        {
            BooleanVariable item = new BooleanVariable(id, name);
            innerList.Add(id, item);
            return item;
        }

        public ByteVariable AddByteVariable(Int32 id, String name)
        {
            ByteVariable item = new ByteVariable(id, name);
            innerList.Add(id, item);
            return item;
        }

        public CharVariable AddCharVariable(Int32 id, String name)
        {
            CharVariable item = new CharVariable(id, name);
            innerList.Add(id, item);
            return item;
        }

        public CodeunitVariable AddCodeunitVariable(Int32 id, String name, Int32 subType)
        {
            CodeunitVariable item = new CodeunitVariable(id, name, subType);
            innerList.Add(id, item);
            return item;
        }

        public CodeVariable AddCodeVariable(Int32 id, String name, Int32? dataLength = null)
        {
            CodeVariable item = new CodeVariable(id, name, dataLength);
            innerList.Add(id, item);
            return item;
        }

        public DateFormulaVariable AddDateFormulaVariable(Int32 id, String name)
        {
            DateFormulaVariable item = new DateFormulaVariable(id, name);
            innerList.Add(id, item);
            return item;
        }

        public DateTimeVariable AddDateTimeVariable(Int32 id, String name)
        {
            DateTimeVariable item = new DateTimeVariable(id, name);
            innerList.Add(id, item);
            return item;
        }

        public DateVariable AddDateVariable(Int32 id, String name)
        {
            DateVariable item = new DateVariable(id, name);
            innerList.Add(id, item);
            return item;
        }

        public DecimalVariable AddDecimalVariable(Int32 id, String name)
        {
            DecimalVariable item = new DecimalVariable(id, name);
            innerList.Add(id, item);
            return item;
        }

        public DialogVariable AddDialogVariable(Int32 id, String name)
        {
            DialogVariable item = new DialogVariable(id, name);
            innerList.Add(id, item);
            return item;
        }

        public DotNetVariable AddDotNetVariable(Int32 id, String name, String subType)
        {
            DotNetVariable item = new DotNetVariable(id, name, subType);
            innerList.Add(id, item);
            return item;
        }

        public DurationVariable AddDurationVariable(Int32 id, String name)
        {
            DurationVariable item = new DurationVariable(id, name);
            innerList.Add(id, item);
            return item;
        }

        public ExecutionModeVariable AddExecutionModeVariable(Int32 id, String name)
        {
            ExecutionModeVariable item = new ExecutionModeVariable(id, name);
            innerList.Add(id, item);
            return item;
        }

        public FieldRefVariable AddFieldRefVariable(Int32 id, String name)
        {
            FieldRefVariable item = new FieldRefVariable(id, name);
            innerList.Add(id, item);
            return item;
        }

        public FileVariable AddFileVariable(Int32 id, String name)
        {
            FileVariable item = new FileVariable(id, name);
            innerList.Add(id, item);
            return item;
        }

        public GuidVariable AddGuidVariable(Int32 id, String name)
        {
            GuidVariable item = new GuidVariable(id, name);
            innerList.Add(id, item);
            return item;
        }

        public InStreamVariable AddInStreamVariable(Int32 id, String name)
        {
            InStreamVariable item = new InStreamVariable(id, name);
            innerList.Add(id, item);
            return item;
        }

        public IntegerVariable AddIntegerVariable(Int32 id, String name)
        {
            IntegerVariable item = new IntegerVariable(id, name);
            innerList.Add(id, item);
            return item;
        }

        public KeyRefVariable AddKeyRefVariable(Int32 id, String name)
        {
            KeyRefVariable item = new KeyRefVariable(id, name);
            innerList.Add(id, item);
            return item;
        }

        public OcxVariable AddOcxVariable(Int32 id, String name, String subType)
        {
            OcxVariable item = new OcxVariable(id, name, subType);
            innerList.Add(id, item);
            return item;
        }

        public OptionVariable AddOptionVariable(Int32 id, String name)
        {
            OptionVariable item = new OptionVariable(id, name);
            innerList.Add(id, item);
            return item;
        }

        public OutStreamVariable AddOutStreamVariable(Int32 id, String name)
        {
            OutStreamVariable item = new OutStreamVariable(id, name);
            innerList.Add(id, item);
            return item;
        }

        public PageVariable AddPageVariable(Int32 id, String name, Int32 subType)
        {
            PageVariable item = new PageVariable(id, name, subType);
            innerList.Add(id, item);
            return item;
        }

        public QueryVariable AddQueryVariable(Int32 id, String name, Int32 subType)
        {
            QueryVariable item = new QueryVariable(id, name, subType);
            innerList.Add(id, item);
            return item;
        }

        public RecordIDVariable AddRecordIDVariable(Int32 id, String name)
        {
            RecordIDVariable item = new RecordIDVariable(id, name);
            innerList.Add(id, item);
            return item;
        }

        public RecordRefVariable AddRecordRefVariable(Int32 id, String name)
        {
            RecordRefVariable item = new RecordRefVariable(id, name);
            innerList.Add(id, item);
            return item;
        }

        public RecordVariable AddRecordVariable(Int32 id, String name, Int32 subType)
        {
            RecordVariable item = new RecordVariable(id, name, subType);
            innerList.Add(id, item);
            return item;
        }

        public ReportVariable AddReportVariable(Int32 id, String name, Int32 subType)
        {
            ReportVariable item = new ReportVariable(id, name, subType);
            innerList.Add(id, item);
            return item;
        }

        public TestPageVariable AddTestPageVariable(Int32 id, String name, Int32 subType)
        {
            TestPageVariable item = new TestPageVariable(id, name, subType);
            innerList.Add(id, item);
            return item;
        }

        public TextConstant AddTextConstant(Int32 id, String name)
        {
            TextConstant item = new TextConstant(id, name);
            innerList.Add(id, item);
            return item;
        }

        public TextVariable AddTextVariable(Int32 id, String name, Int32? dataLength = null)
        {
            TextVariable item = new TextVariable(id, name, dataLength);
            innerList.Add(id, item);
            return item;
        }

        public TimeVariable AddTimeVariable(Int32 id, String name)
        {
            TimeVariable item = new TimeVariable(id, name);
            innerList.Add(id, item);
            return item;
        }

        public TransactionTypeVariable AddTransactionTypeVariable(Int32 id, String name)
        {
            TransactionTypeVariable item = new TransactionTypeVariable(id, name);
            innerList.Add(id, item);
            return item;
        }

        public VariantVariable AddVariantVariable(Int32 id, String name)
        {
            VariantVariable item = new VariantVariable(id, name);
            innerList.Add(id, item);
            return item;
        }

        public XmlPortVariable AddXmlPortVariable(Int32 id, String name, Int32 subType)
        {
            XmlPortVariable item = new XmlPortVariable(id, name, subType);
            innerList.Add(id, item);
            return item;
        }

        public bool Remove(Int32 id)
        {
            return innerList.Remove(id);
        }

        public IEnumerator<Variable> GetEnumerator()
        {
            return innerList.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerList.Values.GetEnumerator();
        }
    }
}
