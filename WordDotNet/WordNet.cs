using System.Linq.Expressions;
namespace WordDotNet
{
    public class WordNet : Query.WordQuery
    {
        public WordNet()
            : base(new Query.QueryContext(new Query.WordQueryProvider()), Expression.Empty()) {}
        public WordNet Adjective()
        {
            Context.Provider.SetType(Query.WordType.Adjective);
            return this;
        }
    }
}
