using System.Text.Json.Serialization;

namespace EFCoreRelationships
{
    public class FlightDepartments
    {
        public int Id { get; set; }
        public string Name { get; set; }= string.Empty;
        [JsonIgnore]
        public List<Tickets> Tickets { get; set; }
    }
}
