using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordDotNet;
using System.Linq;
namespace Tests
{
    [TestClass]
    public class StringApiTests
    {
        [TestMethod]
        public void MyTest()
        {
            var a = new WordNet().Adjective().ToList()[0];
            Assert.AreEqual(a, "a");//todo: test for real adjectives
        }
        [TestMethod]
        public void IsEnumerable()
        {
            var any = "word".Net().AsEnumerable().Any();
        }
        [TestMethod]
        public void IsQueryable() => "word".Net().AsQueryable();

/*        [TestMethod]
        public void NonWordIsNull()
        {
            const string nonword = "notaword";
            Assert.IsNull(nonword.Net().NetRoot());
        }
*/
        [TestMethod]
        public void WordIsNotNull()
        {
            const string word = "word";
            Assert.IsNotNull(word.Net().NetRoot());
        }
    }
}
