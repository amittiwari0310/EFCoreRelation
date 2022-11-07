using System.Text.Json.Serialization;

namespace EFCoreRelationships
{
    public class Passenger
    {
        public int Id { get; set; }
       
        public string Name { get; set; }=String.Empty;
        [JsonIgnore]
        public Tickets Tickets { get; set; }
        public int TicketsId { get; set; }
        

    }
}
