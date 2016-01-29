using RunnerTools.Core;
using System;

namespace RunnerTools.Converters
{
    public static class RunningPace
    {
        private const double MILE_TO_KM = 1.609344;

        public static Pace MinPerKmToMinPerMile(Pace paceInKms)
        {
            int totalSecomds = paceInKms.Minutes * 60 + paceInKms.Seconds;
            double totalSecondsInMiles = totalSecomds * MILE_TO_KM;
            int minutesValueInMiles = (int)Math.Floor(totalSecondsInMiles / 60);
            double secondsValueInMiles = totalSecondsInMiles - minutesValueInMiles * 60;
            int secondsFloored = (int)Math.Floor(secondsValueInMiles);
            var miliseconds = (int)(Math.Round(secondsValueInMiles - secondsFloored, 3, MidpointRounding.ToEven) * 1000);

            return new Pace(minutesValueInMiles, secondsFloored, miliseconds);
            //string paceInMiles = string.Format("{0}:{1}", minutesValueInMiles, secondsValueInMiles.ToString("##.###"));
            //return new Pace(paceInMiles);
        }

        public static Pace MinPerMileToMinPerKm(Pace paceInMiles)
        {
            int totalSeconds = paceInMiles.Minutes * 60 + paceInMiles.Seconds;
            double totalSecondsInKms = totalSeconds / MILE_TO_KM;
            int minutesValueInKms = (int)Math.Floor(totalSecondsInKms / 60);
            double secondsValueInKms = totalSecondsInKms - minutesValueInKms * 60;

            string paceInKms = string.Format("{0}:{1}", minutesValueInKms, secondsValueInKms.ToString("##.###"));
            return new Pace(paceInKms);
        }
    }
}
