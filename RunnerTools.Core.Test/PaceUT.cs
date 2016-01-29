using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace RunnerTools.Core.Test
{
    [TestClass]
    public class PaceUT
    {
        [TestMethod, TestCategory("Pace Object")]
        public void CreatePaceFromMinSec_SUCCESS()
        {
            var pace = new Pace("01:23");
            pace.Minutes.Should().Be(1);
            pace.Seconds.Should().Be(23);
            pace.ToString(@"mm\:ss").Should().Be("01:23");
        }

        [TestMethod, TestCategory("Pace Object")]
        public void CreatePaceFromMinSecMil_SUCCESS()
        {
            var pace = new Pace("1:23.456");
            pace.Minutes.Should().Be(1);
            pace.Seconds.Should().Be(23);
            pace.Milliseconds.Should().Be(456);
            pace.ToString(@"mm\:ss\.fff").Should().Be("01:23.456");
        }
    }
}
