namespace ABC_Resturant.Model
{
    public class Facility
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Status { get; set; }
        public int ResturantId { get; set; }
        public Resturant Resturant { get; set; }
    }
}
