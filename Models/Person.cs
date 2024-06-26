using System.Text.Json.Serialization;

namespace Deserializer.Models
{
    public class Person
    {
        public int Id { get; set; }

        //[JsonPropertyName("firstname")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? FirstName { get; set; }
        
        [JsonPropertyName("surname")]
        public string? LastName { get; set; }
        public int Age { get; set; }

        [JsonIgnore]
        public bool IsAlive { get; set; }
        public Address? Address { get; set; }
        public IList<Phone>? PhoneNumbers { get; set; }
        
    }
}