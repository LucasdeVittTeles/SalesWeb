using SalesWeb.Server.Models;

namespace SalesWeb.Server.DTOs
{
    public class SellerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public double BaseSalary { get; set; }
        //public Department Department { get; set; }
        public int DepartmentId { get; set; }
    }
}
