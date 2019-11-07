using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDocker.Models
{
    public class TodoModel
    {
        //TodoId
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId ObjetId { get; set; }
        [BsonRequired]
        public string Tamanho { get; set; }
        public string Sabor { get; set; }
        public string Personalizacao { get; set; }
        public decimal Valor_total { get; set; }
        public string Tempo_preparo { get; set; }
      
    }
}
