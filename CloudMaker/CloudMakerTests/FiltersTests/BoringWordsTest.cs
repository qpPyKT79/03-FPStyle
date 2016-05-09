using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudMaker.Filters;
using NUnit.Framework;

namespace CloudMakerTests.FiltersTests
{
    [TestFixture]
    public class BoringWordsTest
    {
        private BoringWordsFilter sut;
        [SetUp]
        public void SetUp() => sut = new BoringWordsFilter();

        [Test]
        public void FilterWords_AllBoring()
        {
            var testWords = new List<string> { "of", "as", "the", "versus" };
            var actual = sut.FilterWords(testWords);
            CollectionAssert.IsEmpty(actual);
        }
        [Test]
        public void FilterWords_When_Empty_Input()
        {
            var testWords = new List<string>();
            var actual = sut.FilterWords(testWords);
            CollectionAssert.IsEmpty(actual);
        }
        [Test]
        public void Filtering_Boring_Words()
        {
            var testWords = new List<string> { "NotBoringWord", "NotBoringWordToo", "of", "the" };
            var actual = sut.FilterWords(testWords);
            var excepted = new List<string> { "NotBoringWord", "NotBoringWordToo" };
            CollectionAssert.AreEqual(excepted, actual);
        }
    }
}
