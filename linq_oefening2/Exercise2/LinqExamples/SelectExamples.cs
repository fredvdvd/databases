using System;
using System.Collections.Generic;
using System.Linq;
using LinqExamples.Models;


namespace LinqExamples
{
    public class SelectExamples
    {
        public IList<double> RoundDoublesUsingProjection(IEnumerable<double> doubles)
        {
            var result = from unit in doubles select Math.Round(unit,0);
            return result.ToList();
            //            var result = doubles.Select(num => Math.Round(num)).ToList();
            //Tip: use the "ToList" extension method to convert an IEnumerable to a List
        }

        public IList<AngleInfo> ConvertAnglesToAngleInfos(IEnumerable<double> anglesInDegrees)
        {
            var result = anglesInDegrees.Select(degree => new AngleInfo
            {
                Angle = degree,
                Cosinus = Math.Cos(degree * Math.PI / 180),
                Sinus = Math.Sin(degree * Math.PI / 180)
            });
            return result.ToList();
            //Tip: use the "ToList" extension method to convert an IEnumerable to a List
            // Tip: angleInDegrees to radian => angleInRadian = angleInDegree * π / 180
        }
    }
}
