using MongoDB.Bson.Serialization.Attributes;

namespace JobAPI.Models
{
    public class JobCreateDTO
    {
        [BsonElement("title")]
        public string? Title { get; set; }

        [BsonElement("description")]
        public string? Description { get; set; }

        [BsonElement("author")]
        public string? Author { get; set; }

        [BsonElement("condition")]
        public string? Condition { get; set; }
    }
}
