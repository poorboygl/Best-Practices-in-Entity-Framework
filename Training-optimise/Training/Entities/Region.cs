using System.Diagnostics.Metrics;

namespace Training.Entities
{
    public class Region
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Country> Countries { get; set; } 
    }
}
