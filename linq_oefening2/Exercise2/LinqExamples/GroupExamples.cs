using System;
using System.Collections.Generic;
using System.Linq;
using LinqExamples.Models;

namespace LinqExamples
{
    public class GroupExamples
    {
        public IList<IGrouping<int, int>> GroupEvenAndOddNumbers(int[] numbers)
        {
            var result = numbers.GroupBy(even => even % 2).Select(even =>even);
            return result.ToList();
            //Tip: use the "ToList" extension method to convert an IEnumerable to a List
        }

        public IList<PersonAgeGroup> GroupPersonsByAge(List<Person> persons)
        {
            var result = persons.GroupBy(person => person.Age)
                .Select(PersonAgeGroup => new PersonAgeGroup { Persons = PersonAgeGroup, Age = PersonAgeGroup.Key } );
            return result.ToList();
            //Tip: use the "ToList" extension method to convert an IEnumerable to a List
        }
    }
}