﻿namespace ABC_Resturant.Model
{
    public class Review
    {
        public int Id { get; set; }
        public string Comment { get; set; } 
        public string Rating { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int ResturantId { get; set; }
        public Resturant Resturant { get; set; }
    }
}

