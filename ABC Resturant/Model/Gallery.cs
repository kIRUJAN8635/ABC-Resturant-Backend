namespace ABC_Resturant.Model
{
    public class Gallery
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public int ResturantId { get; set; }
        public Resturant Resturant { get; set; }
    }
}
