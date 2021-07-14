using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyser
{
    public class MoodAnalyserCheck
    {
        string message;
        public MoodAnalyserCheck(string message)
        {
            this.message = message;
        }

        public string CheckMood()
        {
            try
            {
                if (this.message.ToLower().Contains("sad"))
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
                return "happy";
            }
            
        }
    }
}
