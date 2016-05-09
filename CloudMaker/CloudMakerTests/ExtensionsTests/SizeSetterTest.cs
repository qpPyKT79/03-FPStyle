using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudMaker;
using CloudMaker.Extensions;
using NUnit.Framework;

namespace CloudMakerTests.ExtensionsTests
{
    [TestFixture]
    public class SizeSetterTest
    {
        [Test]
        public void SetSizeTest()
        {
            var actual = new List<CloudTag>
            {
                new CloudTag("a").SetFrequency(32),
                new CloudTag("b").SetFrequency(64)
            }.SetSize(1, 25);
            Assert.AreEqual(actual[0].TagSize.Width, 10, 5);
            Assert.AreEqual(actual[1].TagSize.Width, 295, 5);
        }

        [Test]
        public void Set_Size_When_Frequencies_Are_Not_Set()
        {
            var actual = new List<CloudTag>
            {
                new CloudTag("a"),
                new CloudTag("b")
            }.SetSize(1, 25);
            Assert.AreEqual(actual[0].TagSize.Width, 10, 5);
            Assert.AreEqual(actual[1].TagSize.Width, 10, 5);
        }

        [Test]
        public void Set_Size_To_Empty_List() =>
            CollectionAssert.IsEmpty(new List<CloudTag>().SetSize(1, 25));
    }
}
