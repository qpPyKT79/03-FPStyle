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
    class NormalizerTest
    {
        private Normalizer sut;

        [SetUp]
        public void SetUp() => sut = new Normalizer();

        [Test]
        public void Normalize_Words()
        {
            var testWords = new List<string> { "counting", "thinks" };
            var actual = sut.FilterWords(testWords);
            var excepted = new List<string> { "count", "think" };
            CollectionAssert.AreEqual(excepted, actual);
        }

        [Test]
        public void NormalizeWord_When_Nothing_To_Normilize()
        {
            var testWords = new List<string> { "computer", "fruit", "number" };
            var actual = sut.FilterWords(testWords);
            var excepted = new List<string> { "computer", "fruit", "number" };
            CollectionAssert.AreEqual(excepted, actual);
        }

        [Test]
        public void NormalizeWord_When_Empty_Input()
        {
            var testWords = new List<string>();
            var actual = sut.FilterWords(testWords);
            CollectionAssert.IsEmpty(actual);
        }

        [Test]
        public void Normalize_Unexisting_Words()
        {
            var testWords = new List<string> { "sffwfsfsfsfsdeggrftgr", "ThisWordIsNotExist" };
            var actual = sut.FilterWords(testWords);
            CollectionAssert.IsEmpty(actual);
        }
    }
}
