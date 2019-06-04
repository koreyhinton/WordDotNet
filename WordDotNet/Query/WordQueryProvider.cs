using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
namespace WordDotNet.Query
{
    public enum WordType
    {
        Adjective,
        Adverb,
        Noun,
        Verb
    }
    public class WordQueryProvider : IQueryProvider
    {
        #region TODO: REMOVE AND REPLACE WITH REAL BACKEND
        private List<string> _adjectives = new List<string> { "a", "b", "c" };
        private List<string> _adverbs = new List<string> { "d", "e", "f" };
        private List<string> _verbs = new List<string> { "g", "h", "i" };
        private List<string> _nouns = new List<string> { "j", "k", "l" };
        #endregion
/*        public WordQueryProvider(QueryContext context)
        {
            _context = context;
        }
        private readonly QueryContext _context;*/
        private WordType _type;
        public void SetType(WordType type)
        {
            _type = type;
        }
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            if (expression == null)
                throw new ArgumentNullException(nameof(expression));
            if (!typeof(IQueryable<TElement>).IsAssignableFrom(expression.Type))
                throw new ArgumentException(nameof(expression));
            return (IQueryable<TElement>)new WordQuery(new QueryContext(this), expression);  //_context, expression);
        }
        public IQueryable CreateQuery(Expression expression)
        {
            return new WordQuery(new QueryContext(this), expression); //_context, expression);
        }
        public TResult Execute<TResult>(Expression expression)
        {
            IQueryable<string> underlyingQueryable;//TODO: replace with backend
            switch (this._type)
            {
            case WordType.Adjective:
                underlyingQueryable = _adjectives.AsQueryable();
                break;
            case WordType.Adverb:
                underlyingQueryable = _adverbs.AsQueryable();
                break;
            case WordType.Noun:
                underlyingQueryable = _nouns.AsQueryable();
                break;
            case WordType.Verb:
                underlyingQueryable = _verbs.AsQueryable();
                break;
            default:
                underlyingQueryable = _adjectives.Concat(_adverbs).Concat(_nouns).Concat(_verbs).AsQueryable();
                break;
            }
            return (TResult)(underlyingQueryable);
        }
        public object Execute(Expression expression)
        {
            return Execute<string>(expression);
        }
    }
}
