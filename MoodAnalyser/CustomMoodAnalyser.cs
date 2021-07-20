using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyser
{
    public class CustomMoodAnalyser:Exception
    {

        ExceptionType type;

        //Enum for excpetion types
        public enum ExceptionType
        {
            NULL_EXCEPTION,EMPTY_EXCEPTION,CLASS_NOT_FOUND,CONSTRUCTOR_NOT_FOUND,NO_SUCH_METHOD
        }

        //parameterized constructor
        public CustomMoodAnalyser(ExceptionType type, string message ): base(message)
        {
            this.type = type;
        }
    }
}
