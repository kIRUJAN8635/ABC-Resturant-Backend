namespace ABC_Resturant.Model
{
    public class Offer
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Discount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public int ResturantId { get; set; }
        public Resturant Resturant { get; set; }

    }
}
