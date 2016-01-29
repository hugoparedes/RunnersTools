using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using RunnerTools.Core;

namespace RunnerTools.Converters.Test
{
    [TestClass]
    public class ConvertMilesToKilometersUT
    {
        private const double MILE_TO_KM = 1.609344;

        [TestMethod, TestCategory("Converters")]
        public void FromMinutesPerMileToMinutesToKilometer()
        {
            var paceValue = new Pace("9:57");
            Pace paceInKms = RunningPace.MinPerMileToMinPerKm(paceValue);
            paceInKms.ToString().Should().Be("6:10.959");
        }
    }
}
