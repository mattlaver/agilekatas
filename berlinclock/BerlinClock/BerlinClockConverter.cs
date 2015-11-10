using System;
using System.Text;

namespace BerlinClock
{
    public class BerlinClockConverter
    {

        private string SingleMinutes(int minutes)
        {
            var singleMinute = (minutes % 5);

            switch (singleMinute)
            {
                case 1: return "YOOO";
                case 2: return "YYOO";
                case 3: return "YYYO";
                case 4: return "YYYY";
                default: return "OOOO";
            }
        }

        private string FiveMinutes(int minutes)
        {
            var fiveMinutes = (int)Math.Floor((double)minutes/5);

            var sb = new StringBuilder();
            for (var i = 1; i < 12; i++)
            {
                if (i <= fiveMinutes)
                {
                    sb.Append((i % 3) == 0 ? "R" : "Y");
                }
                else sb.Append("O");

            }

            return sb.ToString();
        }

        private string SingleHours(int hours)
        {
            var singleMinute = (hours % 5);

            switch (singleMinute)
            {
                case 1: return "ROOO";
                case 2: return "RROO";
                case 3: return "RRRO";
                case 4: return "RRRR";
                default: return "OOOO";
            }
        }

        private string FiveHours(int hours)
        {
            var fiveHours = (int)Math.Floor((double)hours / 5);

            var sb = new StringBuilder();
            for (var i = 1; i < 5; i++)
            {
                sb.Append(i <= fiveHours ? "R" : "O");
            }

            return sb.ToString();
        }

        private string Seconds(int seconds)
        {
            return ((seconds%2) != 0) ? "O" : "Y";
        }

        public BerlinClock Run(DateTime time)
        {
            var dt = Convert.ToDateTime(time);

            var berlin = new BerlinClock();
            berlin.SingleMinutes = SingleMinutes(dt.Minute);
            berlin.FiveMinutes = FiveMinutes(dt.Minute);
            berlin.SingleHours = SingleHours(dt.Hour);
            berlin.FiveHours = FiveHours(dt.Hour);
            berlin.Seconds = Seconds(dt.Second);

            return berlin;
        }
    }
}
