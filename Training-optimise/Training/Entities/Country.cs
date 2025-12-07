namespace Training.Entities
{
    public class Country
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int RegionID { get; set; } 
        public Region Region { get; set; }  
        public ICollection<SalesRecord> SalesRecords { get; set; } 
    }
}
