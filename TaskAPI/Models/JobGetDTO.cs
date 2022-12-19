using MongoDB.Bson.Serialization.Attributes;

namespace JobAPI.Models
{
    public class JobGetDTO
    {
        public Guid Id { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public string? Author { get; set; }

        public string? Condition { get; set; }
    }
}
