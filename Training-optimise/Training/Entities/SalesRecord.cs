using Microsoft.EntityFrameworkCore;

namespace Training.Entities
{
    //[Index(nameof(OrderDate), Name = "IX_SalesRecords_OrderDate")]
    public class SalesRecord
    {
        public int Id { get; set; }
        public string SalesChannel { get; set; }
        public string OrderPriority { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderID { get; set; }
        public DateTime ShipDate { get; set; }
        public int UnitsSold { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal UnitCost { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal TotalCost { get; set; }
        public decimal TotalProfit { get; set; }
        public int CountryID { get; set; }  
        public Country Country { get; set; } 
    }
}
