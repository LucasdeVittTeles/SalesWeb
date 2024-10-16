using SalesWeb.Server.Models;

namespace SalesWeb.Server.DTOs
{
    public class SellerDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public double BaseSalary { get; set; }

        //public Department Department { get; set; }
        public int DepartmentId { get; set; }

        public SellerDto()
        {
        }

        public SellerDto(int id, string name, string email, DateTime birthDate, double baseSalary, int departmentId)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            DepartmentId = departmentId;
        }

        /*
        public SellerDto(Seller seller) : this(seller.Id, seller.Name, seller.Email, seller.BirthDate, seller.BaseSalary, seller.DepartmentId)
        {
           
        }
        */

    }
}
