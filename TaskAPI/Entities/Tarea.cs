using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TaskAPI.Entities
{
    public class Tarea
    {
        [BsonId]
        public Guid Id { get; set; }

        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("creation")]
        public string Creation { get; set; }

        [BsonElement("update")]
        public string Update { get; set; }

        [BsonElement("author")]
        public string Author { get; set; }

        [BsonElement("condition")]
        public string Condition { get; set; }
    }
}
