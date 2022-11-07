using System.Text.Json.Serialization;

namespace EFCoreRelationships
{
    public class CreateTicketsDto
    {
        public string Name { get; set; } = String.Empty;
        public int UserId { get; set; }
        public string?Description { get;  set; }
    }
}
