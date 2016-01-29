using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using RunnerTools.Core;

namespace RunnerTools.Converters.Test
{
    [TestClass]
    public class ConvertKilometersToMilesUT
    {
        private const double MILE_TO_KM = 1.609344;

        [TestMethod, TestCategory("Converters")]
        public void FromMinutesPerKilometerToMinutesToMile()
        {
            var paceValue = new Pace("06:11");
            Pace minKm = RunningPace.MinPerKmToMinPerMile(paceValue);
            minKm.ToString().Should().Be("9:57.067");
        }
    }
}
