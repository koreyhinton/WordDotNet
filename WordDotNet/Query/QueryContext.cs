namespace WordDotNet.Query
{
    public class QueryContext
    {
        public QueryContext(WordQueryProvider provider)
        {
            Provider = provider;
        }
        public WordQueryProvider Provider { get; }
    }
}
