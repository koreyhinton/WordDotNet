using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Linq.Expressions;
namespace WordDotNet.Query
{
    public class WordQuery : IOrderedQueryable<string>
    {
        public WordQuery(QueryContext context, Expression expression)
        {
            Context = context;
            Expression = expression;
        }
        protected readonly QueryContext Context;
        public Type ElementType => typeof(string);
        public Expression Expression { get; }
        public IQueryProvider Provider => Context.Provider;
        public IEnumerator<string> GetEnumerator()
            => Context.Provider.Execute<IEnumerable<string>>(Expression).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator()
            => Context.Provider.Execute<IEnumerable<string>>(Expression).GetEnumerator();
    }
}
