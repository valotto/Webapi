using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CoreDocker.Models
{
    public class TodoModel
    {
        //TodoId
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonRequired]
        
        [BsonElement("ObjetId")]
        public ObjectId ObjetId { get; set; }
        
        public string Tamanho { get; set; }
        public string Sabor { get; set; }
        public string Personalizacao { get; set; }
        public decimal Valor_total { get; set; }
        public string Tempo_preparo { get; set; }
        public string Mesa_register { get; set; }
      
    }
}
