using System.Linq;

namespace WordDotNet
{
    public interface IWordNet : IOrderedQueryable<string>
    {
        string NetRoot();
    }
    public static class Extensions
    {
        public static IWordNet Net(this string word)
        {
            return new WordRoot(word);
        }
    }
    internal class WordRoot : WordNet, IWordNet
    {
        public WordRoot(string root) : base()
        {
            _root = root;
        }
        private string _root;
        public string NetRoot() => _root;
    }
}
