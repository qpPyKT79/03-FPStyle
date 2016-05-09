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
    public class BoundsGetterTest
    {
        [Test]
        public void GetBoundsTest()
        {
            var actual = new List<CloudTag>
            {
                new CloudTag("a").SetFrequency(32),
                new CloudTag("b").SetFrequency(64)
            }.SetSize(10, 25).GetBounds();
            Assert.AreEqual(actual.Width, 395, 6);
            Assert.AreEqual(actual.Height, 575, 6);
        }
        [Test]
        public void Get_Bounds_When_Frequencies_And_Size_Of_Tags_Are_Not_Set()
        {
            var actual = new List<CloudTag>
            {
                new CloudTag("a"),
                new CloudTag("b")
            }.GetBounds();
            Assert.AreEqual(actual.Width, 1);
            Assert.AreEqual(actual.Height, 1);
        }

        [Test]
        public void Get_Bounds_From_Empty_List()
        {
            var actual = new List<CloudTag>().GetBounds();
            Assert.AreEqual(actual.Width, 0);
            Assert.AreEqual(actual.Height, 0);
        }
    }
}
