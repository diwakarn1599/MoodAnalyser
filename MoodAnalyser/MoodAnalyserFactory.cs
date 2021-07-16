using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Text.RegularExpressions;


namespace MoodAnalyser
{
    public class MoodAnalyserFactory
    {
        public Object CreateMoodAnalyserObject(string className,string constructorName)
        {
            string pattern = constructorName + "$";
            Match res = Regex.Match(className, pattern);

            if (res.Success)
            {
                try
                {
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    Type classType = assembly.GetType(className);
                    var obj = Activator.CreateInstance(classType);
                    return obj;
                }
                catch(CustomMoodAnalyser ex)
                {
                    throw new CustomMoodAnalyser(CustomMoodAnalyser.ExceptionType.CLASS_NOT_FOUND, "Class Not found");
                }
            }
            else
            {
                throw new CustomMoodAnalyser(CustomMoodAnalyser.ExceptionType.CONSTRUCTOR_NOT_FOUND, "Constructor Not found");
            }

        }
    }
}
