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
    public class FrequenciesSetterTest
    {
        [Test]
        public void SetFrequenciesTest()
        {
            var actual = new List<string>
            {"a","a","a","a","a","a","a","a","a","a","a","a","a","a","a","a",
            "b","b","b","b","b","b","b","b",
            "c","c","c","c"}.SetFrequences();
            var excepted = new List<CloudTag>
            {
                new CloudTag("a").SetFrequency(16),
                new CloudTag("b").SetFrequency(8),
                new CloudTag("c").SetFrequency(4)
            };
            CollectionAssert.AreEqual(actual, excepted);
        }

        [Test]
        public void Set_Frequencies_To_Empty_List() =>
            CollectionAssert.IsEmpty(new List<string>().SetFrequences());
    }
}
