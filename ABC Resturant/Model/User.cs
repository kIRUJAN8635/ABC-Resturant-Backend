namespace ABC_Resturant.Model
{
    public class User
    {
        public int Id { get; set; }
        public int AdminId { get; set; }
        public Admin Admin { get; set; }
        public int CustiomerId { get; set; }
        public Customer Customer { get; set; }
        public int StaffId { get; set; }
        public Staff Staff { get; set; }
    }
}
