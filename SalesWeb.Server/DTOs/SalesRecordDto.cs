using SalesWeb.Server.Models.Enums;
using SalesWeb.Server.Models;

namespace SalesWeb.Server.DTOs
{
    public class SalesRecordDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public SaleStatus Status { get; set; }
        public Seller Seller { get; set; }
    }
}
