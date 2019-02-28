using System;
using System.Collections.Generic;
using System.Linq;
using LinqExamples.Models;

namespace LinqExamples
{
    public class OrderByExamples
    {
        public int[] SortNumbersDescending(int[] numbers)
        {
            var result = numbers.OrderByDescending(num => num);
            return result.ToArray();
            //Tip: use the "ToArray" extension method to convert an IEnumerable to an Array
        }

        public IList<Person> SortPersonsOnDescendingAgeAndThenOnDescendingName(List<Person> persons)
        {
            var result = persons.OrderByDescending(person => person.Age).ThenByDescending(person => person.Name);
            return result.ToList();
                //Tip: use the "ToList" extension method to convert an IEnumerable to a List
        }
    }
}