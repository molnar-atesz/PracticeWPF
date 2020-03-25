namespace CovidStat.Models
{
    public class CountryStat
    {
        public string Country { get; set; }
        public int Cases { get; set; }
        public int TodayCases { get; set; }
        public int Deaths { get; set; }
        public int Recovered { get; set; }
    }
}
