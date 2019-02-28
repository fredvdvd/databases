using System;
using System.Collections.Generic;
using System.Linq;
using LinqExamples.Models;

namespace LinqExamples
{
    public class JoinExamples
    {
        public int[] GetIntersection(int[] firstList, int[] secondList)
        {
            var result = firstList.Join(secondList, firstitem => firstitem, seconditem => seconditem, (firstitem, seconditem) => firstitem);
            return result.ToArray();
            //Tip: use the "ToArray" extension method to convert an IEnumerable to an Array
        }

        public IList<string> FindCouplesByAgeUsingJoin(List<Person> boys, List<Person> girls)
        {
            var result = boys.Join(girls, boy => boy.Age, girl => girl.Age, (boy, girl) => boy.Name + " and "+ girl.Name);
            return result.ToList();
            //Tip: use the "ToList" extension method to convert an IEnumerable to a List
        }
    }
}