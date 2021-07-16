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
            //check class name and constructor name are same
            string pattern = constructorName + "$";
            Match res = Regex.Match(className, pattern);

            if (res.Success)
            {
                try
                {
                    //create assemblt object
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    Type classType = assembly.GetType(className);
                    //create object
                    var obj = Activator.CreateInstance(classType);
                    return obj;
                }
                catch(CustomMoodAnalyser ex)
                {
                    //exception if class not found
                    throw new CustomMoodAnalyser(CustomMoodAnalyser.ExceptionType.CLASS_NOT_FOUND, "Class Not found");
                }
            }
            else
            {
                //exception if constructor not found
                throw new CustomMoodAnalyser(CustomMoodAnalyser.ExceptionType.CONSTRUCTOR_NOT_FOUND, "Constructor Not found");
            }

        }

        public Object CreateMoodAnalyserParameterizedConstructor(string className, string constructorName, string message)
        {
            Type type = typeof(MoodAnalyserCheck);
            if (type.Name.Equals(className) || type.FullName.Equals(className))
            {
                if (type.Name.Equals(constructorName))
                {

                    ConstructorInfo constructorInfo = type.GetConstructor(new[] { typeof(string) });
                    var obj = constructorInfo.Invoke(new object[] { message });
                    return obj;
                }
                else
                {
                    throw new CustomMoodAnalyser(CustomMoodAnalyser.ExceptionType.CLASS_NOT_FOUND, "Class Not Found");
                }
            }
            else
            {
                throw new CustomMoodAnalyser(CustomMoodAnalyser.ExceptionType.CONSTRUCTOR_NOT_FOUND, "Constructor not Found");
            }
        }
    }
}
