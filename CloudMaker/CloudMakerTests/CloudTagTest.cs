using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudMaker;
using NUnit.Framework;

namespace CloudMakerTests
{
    [TestFixture]
    class CloudTagTest
    {
        private CloudTag sut;
        [SetUp]
        public void SetUp() => sut = new CloudTag("TestTag");

        [Test]
        public void SetFrequencyTest()
        {
            var actual = sut.SetFrequency(20);
            Assert.AreEqual(actual.Frequency, 20);
        }
        [Test]
        public void SetSizeTest()
        {
            var actual = sut.SetSize(new SizeF(20, 20));
            Assert.AreEqual(actual.TagSize.Height, 20);
            Assert.AreEqual(actual.TagSize.Width, 20);
        }
        [Test]
        public void SetLocationTest()
        {
            var actual = sut.SetLocation(20, 20);
            Assert.AreEqual(actual.X, 20);
            Assert.AreEqual(actual.Y, 20);
        }
    }
}
