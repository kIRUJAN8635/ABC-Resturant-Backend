namespace ABC_Resturant.Model
{
    public class OrderItem
    {
        public int Id { get; set; }
        public string Total { get; set; }
        public string Quality { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int MenuId { get; set; }
        public Menu Menu { get; set; }

    }
}
