namespace ABC_Resturant.Model
{
    public class Querys
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public int CustiomerId { get; set; }
        public Customer Customer { get; set; }
        
    }
}
