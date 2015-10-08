namespace OltivaHotel.PCL.Model
{
    public class MenuItem
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public bool IsTodaysSpecial { get; set; }
    }
}