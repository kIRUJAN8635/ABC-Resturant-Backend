namespace ABC_Resturant.Model
{
    public class Payment
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Amount { get; set; }
        public string Method { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
