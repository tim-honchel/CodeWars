using System;
using Xunit;
using TestCode;

namespace XUnitTestProject
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(new string[] { }, "no one likes this")]
        [InlineData(new string[] { "Tim" }, "Tim likes this")]
        public void Likes(string[] input, string expected)
        {
            Challenge test = new Challenge();
            string actual = test.Likes(input);
            Assert.Equal(expected, actual);
        }
    }
}
