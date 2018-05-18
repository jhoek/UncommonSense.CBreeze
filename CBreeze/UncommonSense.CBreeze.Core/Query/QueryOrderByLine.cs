namespace UncommonSense.CBreeze.Core.Query
{
        public class QueryOrderByLine
    {
        public QueryOrderByLine(string column, QueryOrderByDirection direction)
        {
            Column = column;
            Direction = direction;
        }

        public string Column
        {
            get;
            protected set;
        }

        public QueryOrderByDirection Direction
        {
            get;
            protected set;
        }
    }
}
