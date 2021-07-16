using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyser
{
    public class MoodAnalyserCheck
    {
        string message;
        //defualt constructor
        public MoodAnalyserCheck()
        {
            Console.WriteLine("Default Constructor is invoked using reflection");
        }
        //parameterized constructor
        public MoodAnalyserCheck(string message)
        {
            this.message = message;
        }

        public string CheckMood()
        {
            try
            {
                if (message.Equals(string.Empty))
                {
                    //exeption if message is empty
                    throw new CustomMoodAnalyser(CustomMoodAnalyser.ExceptionType.EMPTY_EXCEPTION, "Mood should not be empty");
                }
                else if (this.message.ToLower().Contains("sad"))
                {
                    return "sad";
                }
                else
                {
                    return "happy";
                }
            }
            catch(NullReferenceException)
            {
                //exeption if message is null
                throw new CustomMoodAnalyser(CustomMoodAnalyser.ExceptionType.NULL_EXCEPTION, "mood should not be null");
            }
            
        }
    }
}
