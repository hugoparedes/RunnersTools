using System;

namespace RunnerTools.Core
{
    public struct Pace
    {
        #region Properties

        /// <summary>
        /// Gets the minutes of the pace represented by this instance.
        /// </summary>
        public int Minutes { get; private set; }

        /// <summary>
        /// Gets the seconds of the pace represented by this instance.
        /// </summary>
        public int Seconds { get; private set; }

        /// <summary>
        /// Gets the milliseconds of the pace represented by this instance.
        /// </summary>
        public int Milliseconds { get; private set; }

        /// <summary>
        /// Represents the pace value in one of following formats {mm:ss} or {mm:ss:fff}.
        /// </summary>
        /// <remarks>
        /// Notation: 'mm = minutes', 'ss = seconds' and 'fff = milliseconds'.
        /// </remarks>
        /// <example>
        /// <para>05:23, means 5 minutes and 23 seconds.</para>
        /// <para>07:46.673, means 7 minutes, 46 seconds and 673 milliseconds.</para>
        /// </example>
        public string ToString(string format)
        {
            var value = new TimeSpan(0, 0, Minutes, Seconds, Milliseconds);
            return value.ToString(format);
        }

        public override string ToString()
        {
            var value = new TimeSpan(0, 0, Minutes, Seconds, Milliseconds);
            return value.ToString(@"%m\:ss\.fff");
        }

        #endregion

        #region ctor

        /// <summary>
        /// Represents a running pace expressed in minutes, seconds and milliseconds.
        /// </summary>
        /// <param name="value">The pace represented in minutes:seconds (mm:ss) or minutes:seconds.milliseconds (mm:ss:fff)</param>
        public Pace(string value)
        {
            TimeSpan ts;
            if (TimeSpan.TryParseExact(value, @"%m\:ss", null, out ts))
            {
                Minutes = ts.Minutes;
                Seconds = ts.Seconds;
                Milliseconds = 0;
            }
            else if (TimeSpan.TryParseExact(value, @"%m\:ss\.fff", null, out ts))
            {
                Minutes = ts.Minutes;
                Seconds = ts.Seconds;
                Milliseconds = ts.Milliseconds;
            }
            else
            {
                throw new InvalidCastException("Make sure the pace is in one of the following formats {mm:ss} or {mm:ss:fff}, where 'mm = minutes', 'ss = seconds' and 'fff = milliseconds'.");
            }
        }

        /// <summary>
        /// Represents a running pace expressed in minutes, seconds and milliseconds.
        /// </summary>
        /// <param name="minutes">The minutes (1 through 59)</param>
        /// <param name="seconds">The seconds (1 through 59)</param>
        public Pace(int minutes, int seconds)
        {
            Minutes = minutes;
            Seconds = seconds;
            Milliseconds = 0;
        }

        /// <summary>
        /// Represents a running pace expressed in minutes, seconds and milliseconds.
        /// </summary>
        /// <param name="minutes">The minutes (1 through 59)</param>
        /// <param name="seconds">The seconds (1 through 59)</param>
        /// <param name="milliseconds">The milliseconds (1 through 999)</param>
        public Pace(int minutes, int seconds, int milliseconds)
        {
            Minutes = minutes;
            Seconds = seconds;
            Milliseconds = milliseconds;
        }

        #endregion
    }
}
