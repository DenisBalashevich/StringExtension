using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringConverter;
namespace StringConverterTest
{
    [TestClass]
    public class StringConverterTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ToInt_Null_ArgumentException()
        {
            string number = null;

            StringConverter.StringConverter.ToInt(number);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ToInt_Empty_ArgumentException()
        {
            string number = string.Empty;

            number.ToInt();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ToInt_Whitespace_ArgumentException()
        {
            string number = "    ";

            number.ToInt();
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ToInt_StringWithWords_ArgumentException()
        {
            string number = "Ya ne rabotay";

            number.ToInt();
        }

        [TestMethod]
        public void ToInt_MinInt_ArgumentException()
        {
            string number = int.MinValue.ToString();

            int result = number.ToInt();

            Assert.AreEqual(result, int.MinValue);
        }

        [TestMethod]
        public void ToInt_MaxInt_ArgumentException()
        {
            string number = int.MaxValue.ToString();

            int result = number.ToInt();

            Assert.AreEqual(result, int.MaxValue);
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void ToInt_MoreThanMaxValueInt_ArgumentException()
        {
            string number = "111111111111111111111111111111";

            int result = number.ToInt();
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void ToInt_LessThanMaxValueInt_ArgumentException()
        {
            string number = "-111111111111111111111111111111";

            int result = number.ToInt();
        }

        [TestMethod]
        public void ToInt_Zero_ArgumentException()
        {
            string number = "0";

            int result = number.ToInt();

            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void ToInt_Negative_ArgumentException()
        {

            string number = "-1";

            int result = number.ToInt();

            Assert.AreEqual(result, -1);
        }
    }
}
