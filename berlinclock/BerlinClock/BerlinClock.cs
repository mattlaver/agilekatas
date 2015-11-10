namespace BerlinClock
{
    public class BerlinClock
    {
      
        public string SingleMinutes { get; set; }
        public string FiveMinutes { get; set; }
        public string SingleHours { get; set; }
        public string FiveHours { get; set; }
        public string Seconds { get; set; }


        public BerlinClock()
        {
            
        }

        public string Time()
        {
            return $"{Seconds}{FiveHours}{SingleHours}{FiveMinutes}{SingleMinutes}";
        }

        public BerlinClock(string singleMinutes, string fiveMinutes, string singleHours, string fiveHours, string seconds)
        {  
            SingleMinutes = singleMinutes;
            FiveMinutes = fiveMinutes;
            SingleHours = singleHours;
            FiveHours = fiveHours;
            Seconds = seconds;
        }
    }
}