using System;

namespace hw12.benchmark
{
    public class DifferentMethods
    {

        public void Simple(string newStr)
        {
            for (var i = 0; i < 1; i++)
            {
                newStr += newStr;
            }
        }

        public void Generic<T>(T newStr)
        {
            var str = newStr?.ToString();
            for (var i = 0; i < 1; i++)
            {
                str += newStr;
            }
        }

        public virtual void Virtual(string newStr)
        {
            for (var i = 0; i < 1; i++)
            {
                newStr += newStr;
            }
        }

        public static void Static(string newStr)
        {
            for (var i = 0; i < 1; i++)
            {
                newStr += newStr;
            }
        }

        public void Dynamic(dynamic newStr)
        {
            for (var i = 0; i < 1; i++)
            {
                newStr += newStr;
            }
        }

        public void Reflection(string newStr)
        {
            for (var i = 0; i < 1; i++)
            {
                newStr += newStr;
            }
        }
    }
}