using System.Text.Json.Serialization;

namespace EFCoreRelationships
{
    public class Tickets
    {
      

        public int Id { get; set; }
        public string? Description { get; set; }
        public DateTime? Date { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        public int UserId { get; set; }
        public Passenger Passenger { get; set; }
        public List<FlightDepartments> FlightDepartments { get; set; }
       
    }
}
