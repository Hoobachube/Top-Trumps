namespace TopTrumps.Data.DTOs
{
    public class Card
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Type { get; set; }

        public decimal ABV { get; set; }

        public int Accessibility { get; set; }

        public int Reputation { get; set; }

        public int Popularity { get; set; }

        public string Description { get; set; }
    }
}
