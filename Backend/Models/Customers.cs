using System;
namespace Backend.Models
{
    public class Customers
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime RegisterDate { get; set; }
        public bool Status { get; set; }
    }
}
