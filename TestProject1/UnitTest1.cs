using NUnit.Framework;
using TestCode;

namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(new string[] { }, "no one likes this")]
        [TestCase(new string[] { "Tim" }, "Tim likes this")]
        [TestCase(new string[] { "John" }, "John likes this")]
        [TestCase(new string[] { "Tim", "Gabriel" }, "Tim and Gabriel like this")]
        [TestCase(new string[] { "Tim", "Gabriel", "Andrew" }, "Tim, Gabriel and Andrew like this")]
        [TestCase(new string[] { "Tim", "Gabriel", "Andrew", "M.J." }, "Tim, Gabriel and 2 others like this")]
        public void LikesTest(string[] input, string expected)
        {
            var test = new Challenge();
            var actual = test.Likes(input);
            Assert.AreEqual(actual, expected);
        }

        [TestCase(1, true)]
        [TestCase(153, true)]
        [TestCase(370, true)]
        [TestCase(371, true)]
        [TestCase(407, true)]
        [TestCase(1634, true)]
        [TestCase(8208, true)]
        [TestCase(9474, true)]
        [TestCase(54748, true)]
        [TestCase(92727, true)]
        [TestCase(93084, true)]
        [TestCase(548834, true)]
        [TestCase(1741725, true)]
        [TestCase(4210818, true)]
        [TestCase(9800817, true)]
        [TestCase(9926315, true)]
        [TestCase(24678050, true)]
        [TestCase(88593477, true)]
        [TestCase(146511208, true)]
        [TestCase(472335975, true)]
        [TestCase(534494836, true)]
        [TestCase(912985153, true)]
        [TestCase(4679307774, true)]
        [TestCase(435, false)]
        [TestCase(324, false)]
        [TestCase(4328, false)]
        [TestCase(3248, false)]
        [TestCase(234229983, false)]
        [TestCase(26548238692458, false)]
        [TestCase(11513221922401, false)]
        public void IsNarcissisticTest(long input, bool expected)
        {
            var test = new Challenge();
            var actual = test.IsNarcissistic(input);
            Assert.AreEqual(actual, expected);
        }
 
    }
}