using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyser;

namespace MoodAnalyserTestProject
{
    [TestClass]
    public class UnitTest1
    {
        MoodAnalyserCheck mac,Mac, macNull;
        string msg;
        [TestInitialize]
        public void Setup()
        {
            this.msg = "Im in a Happy Mood";
            mac = new MoodAnalyserCheck(this.msg);
            Mac = new MoodAnalyserCheck("im in sad mood");
            macNull = new MoodAnalyserCheck(null);
        }
        [TestMethod]
        [TestCategory("happy")]
        public void TestMethodForMessageHappy()
        {
            //Arrange
            string actual, expected = "happy";
            //Act
            actual = mac.CheckMood();
            //Assert
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        [TestCategory("sad")]
        public void TestMethodForMessageSad()
        {
            //Arrange
            string actual, expected = "sad";
            //Act
            actual = Mac.CheckMood();
            //Assert
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        [TestCategory("null")]
        public void TestMethodForMessageNull()
        {
            //Arrange
            string actual, expected = "happy";
            //Act
            actual = macNull.CheckMood();
            //Assert
            Assert.AreEqual(actual, expected);
        }
    }
}
