using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyser;
using System.Reflection;
using System;


namespace MoodAnalyserTestProject
{
    [TestClass]
    public class UnitTest1
    {
        MoodAnalyserCheck mac,Mac, macNull, macEmpty,macObj, macPC;
        string msg;
        [TestInitialize]
        public void Setup()
        {
            this.msg = "Im in a Happy Mood";
            mac = new MoodAnalyserCheck(this.msg);
            Mac = new MoodAnalyserCheck("im in sad mood");
            macNull = new MoodAnalyserCheck(null);
            macEmpty = new MoodAnalyserCheck(string.Empty);
            macObj = new MoodAnalyserCheck();
            macPC = new MoodAnalyserCheck("I am in a happy mood");
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
        //**************************************************Object***********************************************
        /// <summary>
        /// TC 1 Class name and constructore name
        /// </summary>
        [TestMethod]
        [TestCategory("objectCreation")]
        public void ObjectCreationUsingReflection()
        {
            
            Object obj = null;
           
            try
            {
                MoodAnalyserFactory moodAnalyse = new MoodAnalyserFactory();
                obj = moodAnalyse.CreateMoodAnalyserObject("MoodAnalyser.MoodAnalyserCheck", "MoodAnalyserCheck");

            }
            catch (CustomMoodAnalyser e)
            {
                throw new Exception(e.Message);
            }
            obj.Equals(macObj);

        }
        /// <summary>
        /// TC 2 class not found
        /// </summary>
        [TestMethod]
        [TestCategory("objectCreationClassException")]
        public void ObjectCreationUsingReflectionClassException()
        {

            Object obj = null;

            try
            {
                MoodAnalyserFactory moodAnalyse = new MoodAnalyserFactory();
                obj = moodAnalyse.CreateMoodAnalyserObject("MoodAnalyser.MoodAnalyserCheckT", "MoodAnalyserCheckT");

            }
            catch (CustomMoodAnalyser e)
            {
                throw new Exception(e.Message);
            }
            obj.Equals(macObj);

        }
        /// <summary>
        /// TC3 constructor not found
        /// </summary>
        [TestMethod]
        [TestCategory("objectCreationConstructorException")]
        public void ObjectCreationUsingReflectionConstructorException()
        {

            Object obj = null;

            try
            {
                MoodAnalyserFactory moodAnalyse = new MoodAnalyserFactory();
                obj = moodAnalyse.CreateMoodAnalyserObject("MoodAnalyser.MoodAnalyserCheck", "MoodAnalyserChec");

            }
            catch (CustomMoodAnalyser e)
            {
                throw new Exception(e.Message);
            }
            obj.Equals(macObj);

        }

        //*****************************************PARAMETERIZED CONSTRUCTOR******************************************************
        /// <summary>
        /// TC1 - Object creation of parameterized constructor 
        /// </summary>
        [TestMethod]
        [TestCategory("ParameterizedConstructor")]
        public void ObjectCreationParameterizedConstructor()
        {

            Object obj;
            
            try
            {
                MoodAnalyserFactory moodAnalyse = new MoodAnalyserFactory();
                obj = moodAnalyse.CreateMoodAnalyserParameterizedConstructor("MoodAnalyser.MoodAnalyserCheck", "MoodAnalyserCheck", "I am in a happy mood");
            }
            catch (CustomMoodAnalyser e)
            {
                throw new Exception(e.Message);
            }
            obj.Equals(macPC);
        }
        /// <summary>
        /// TC2 - Object creation of parameterized constructor class not found exception
        /// </summary>
        [TestMethod]
        [TestCategory("ParameterizedConstructorClassException")]
        public void ObjectCreationParameterizedConstructorClassException()
        {

            Object obj;

            try
            {
                MoodAnalyserFactory moodAnalyse = new MoodAnalyserFactory();
                obj = moodAnalyse.CreateMoodAnalyserParameterizedConstructor("MoodAnalyser.MoodAnalyserCheckT", "MoodAnalyserCheckT", "I am in a happy mood");
            }
            catch (CustomMoodAnalyser e)
            {
                throw new Exception(e.Message);
            }
            obj.Equals(macPC);
        }
        /// <summary>
        /// TC3 - Object creation of parameterized constructor class not found exception
        /// </summary>
        [TestMethod]
        [TestCategory("ParameterizedConstructorClassException")]
        public void ObjectCreationParameterizedConstructorCOnstructorException()
        {

            Object obj;

            try
            {
                MoodAnalyserFactory moodAnalyse = new MoodAnalyserFactory();
                obj = moodAnalyse.CreateMoodAnalyserParameterizedConstructor("MoodAnalyser.MoodAnalyserCheck", "MoodAnalyserChec", "I am in a happy mood");
            }
            catch (CustomMoodAnalyser e)
            {
                throw new Exception(e.Message);
            }
            obj.Equals(macPC);
        }

        //**********************************************INVOKE METHOD***************************************************

        [TestMethod]
        [TestCategory("InvokeMethodReflection")]
        public void InvokeMethodUsingDynamicObject()
        {
            ///<summary>
            ///TC1 -  Method Invoked by object
            ///</summary>  
            //AAA method
            string actual;
            string message = "I am in a happy mood";
            string methodName = "CheckMood";
            string expected = "happy";


            try
            {
                MoodAnalyserFactory ma = new MoodAnalyserFactory();
                actual = ma.InvokeMethod(methodName, message);
            }
            catch (CustomMoodAnalyser e)
            {
                throw new Exception(e.Message);
            }
            actual.Equals(expected);
        }

        [TestMethod]
        [TestCategory("InvokeMethodReflection")]
        public void InvokeMethodUsingDynamicObjectMethodNotException()
        {
            ///<summary>
            ///TC2 -  Method Invoked by object throws method not exception
            ///</summary>  
            //AAA method
            string actual;
            string message = "I am in a happy mood";
            string methodName = "CheckMoo";
            string expected = "happy";


            try
            {
                MoodAnalyserFactory ma = new MoodAnalyserFactory();
                actual = ma.InvokeMethod(methodName, message);
            }
            catch (CustomMoodAnalyser e)
            {
                throw new Exception(e.Message);
            }
            actual.Equals(expected);
        }
    }
}
