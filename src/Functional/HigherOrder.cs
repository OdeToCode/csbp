using System;
using System.Collections.Generic;

namespace Functional
{
    public static class HigherOrder
    {        
        public static void Example()
        {
            var numbers = new[] {3, 5, 7, 9, 1, 13};
            
            foreach(var prime in numbers.FindOddNumbers())
            {
                // .. process the number
                Console.WriteLine(prime);
            }
        }

        private static IEnumerable<int> FindOddNumbers(this IEnumerable<int> values)
        {
            foreach(var value in values)
            {
                if(value % 2 != 0)
                {
                    yield return value;
                }
            }
        }

        private static IEnumerable<int> FindEvenNumbers(this IEnumerable<int> values)
        {
            foreach (var value in values)
            {
                if (value % 2 == 0)
                {
                    yield return value;
                }
            }
        } 

        private static bool IsOdd(int value)
        {
            return value % 2 != 0;
        }

        private static bool IsEven(int value)
        {
            return value % 2 == 0;
        } 
    }
}