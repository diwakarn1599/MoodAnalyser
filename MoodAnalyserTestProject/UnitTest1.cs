using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyser;

namespace MoodAnalyserTestProject
{
    [TestClass]
    public class UnitTest1
    {
        MoodAnalyserCheck mac,Mac, macNull, macEmpty;
        string msg;
        [TestInitialize]
        public void Setup()
        {
            this.msg = "Im in a Happy Mood";
            mac = new MoodAnalyserCheck(this.msg);
            Mac = new MoodAnalyserCheck("im in sad mood");
            macNull = new MoodAnalyserCheck(null);
            macEmpty = new MoodAnalyserCheck(string.Empty);
        }
        //***************************************************HAPPY*****************************************************
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
        //***************************************************SAD*****************************************************
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
        //***************************************************NULL*****************************************************
        [TestMethod]
        [TestCategory("null")]
        public void TestMethodForMessageNull()
        {
            try
            {
                //Arrange
                string actual;
                //Act
                actual = macNull.CheckMood();
                
            }
            catch(CustomMoodAnalyser ex)
            {
                string expected = "mood should not be null";
                //Assert
                Assert.AreEqual(expected,ex.Message);
            }
           
        }
        //***************************************************EMPTY*****************************************************
        [TestMethod]
        [TestCategory("empty")]
        public void TestMethodForMessageEmpty()
        {
            try
            {
                string actual;
                //Act
                actual = macEmpty.CheckMood();
            }
            catch(CustomMoodAnalyser ex)
            {
                //Arrange
               string  expected = "Mood should not be empty";

                //Assert
                Assert.AreEqual(expected,ex.Message);
            }
            
        }
    }
}
