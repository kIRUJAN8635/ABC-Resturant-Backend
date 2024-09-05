namespace ABC_Resturant.Model
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Amount { get; set; }
        public int TableBookingID { get; set; }
        public TableBooking TableBooking { get; set; }
    }
}
