using System;

namespace Functional
{
    public class FunctionsToVariables
    {
         public void Funcs()
         {
            Func<string, int> converter = Convert;

            var result =  Convert("3");
         }

        public int Convert(string value)
        {
            return int.Parse(value);
        }
    }
}