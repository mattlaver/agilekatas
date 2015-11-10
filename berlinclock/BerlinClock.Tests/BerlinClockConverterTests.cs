using System;
using Xunit;

namespace BerlinClock.Tests
{
    public class BerlinClockConverterTests
    {
        [Theory]
        [InlineData("00:00:00", "OOOO")]
        [InlineData("23:59:59", "YYYY")]
        [InlineData("12:32:00", "YYOO")]
        [InlineData("12:34:00", "YYYY")]
        [InlineData("12:35:00", "OOOO")]
        public void ShouldConvertTimeToSingleMinuteRow(string time, string row)
        {
            var converter = new BerlinClockConverter();
            var dt = Convert.ToDateTime(time);

            var berlinclock = converter.Run(dt);

            Assert.Equal(row, berlinclock.SingleMinutes);
        }

        [Theory]
        [InlineData("00:00:00", "OOOOOOOOOOO")]
        [InlineData("23:59:59", "YYRYYRYYRYY")]
        [InlineData("12:04:00", "OOOOOOOOOOO")]
        [InlineData("12:23:00", "YYRYOOOOOOO")]
        [InlineData("12:35:00", "YYRYYRYOOOO")]
        public void ShouldConvertTimeToFiveMinuteRow(string time, string row)
        {
            var converter = new BerlinClockConverter();
            var dt = Convert.ToDateTime(time);

            var berlinClock = converter.Run(dt);

            Assert.Equal(row, berlinClock.FiveMinutes);
        }

        [Theory]
        [InlineData("00:00:00", "OOOO")]
        [InlineData("23:59:59", "RRRO")]
        [InlineData("02:04:00", "RROO")]
        [InlineData("08:23:00", "RRRO")]
        [InlineData("14:35:00", "RRRR")]
        public void ShouldConvertTimeToSingleHourRow(string time, string row)
        {
            var converter = new BerlinClockConverter();
            var dt = Convert.ToDateTime(time);

            var berlinClock = converter.Run(dt);

            Assert.Equal(row, berlinClock.SingleHours);
        }

        [Theory]
        [InlineData("00:00:00", "OOOO")]
        [InlineData("23:59:59", "RRRR")]
        [InlineData("02:04:00", "OOOO")]
        [InlineData("08:23:00", "ROOO")]
        [InlineData("16:35:00", "RRRO")]
        public void ShouldConvertTimeToFiveHourRow(string time, string row)
        {
            var converter = new BerlinClockConverter();
            var dt = Convert.ToDateTime(time);

            var berlinClock = converter.Run(dt);

            Assert.Equal(row, berlinClock.FiveHours);
        }

        [Theory]
        [InlineData("00:00:00", "Y")]
        [InlineData("23:59:59", "O")]
        public void ShouldConvertTimeToSecondsRow(string time, string row)
        {
            var converter = new BerlinClockConverter();
            var dt = Convert.ToDateTime(time);

            var berlinClock = converter.Run(dt);

            Assert.Equal(row, berlinClock.Seconds);
        }

        [Theory]
        [InlineData("00:00:00", "YOOOOOOOOOOOOOOOOOOOOOOO")]
        [InlineData("23:59:59", "ORRRRRRROYYRYYRYYRYYYYYY")]
        [InlineData("16:50:06", "YRRROROOOYYRYYRYYRYOOOOO")]
        [InlineData("11:37:01", "ORROOROOOYYRYYRYOOOOYYOO")]
        public void ShouldIntergrateEntireClock(string time, string row)
        {
            var converter = new BerlinClockConverter();
            var dt = Convert.ToDateTime(time);

            var berlinClock = converter.Run(dt);

            Assert.Equal(row, berlinClock.Time());
        }

    }
}

