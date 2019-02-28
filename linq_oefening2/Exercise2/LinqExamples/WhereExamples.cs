using System;
using System.Collections.Generic;
using System.Linq;
using LinqExamples.Models;

namespace LinqExamples
{
    public class WhereExamples
    {
        public int[] FilterOutNumbersDivisibleByFive(int[] numbers)
        {
            var result = numbers.Where(num => num % 5 == 0);
            return result.ToArray();
            //Tip: use the "ToArray" extension method to convert an IEnumerable to an Array
        }

        public IList<Person> FilterOutPersonsThatAreEighteenOrOlder(List<Person> persons)
        {
            var result = persons.Where(person => person.Age >= 18);
            return result.ToList();
            //Tip: use the "ToList" extension method to convert an IEnumerable to a List
        }
    }
}