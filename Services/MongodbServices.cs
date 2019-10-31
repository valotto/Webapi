using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.Models;
using MongoDB.Bson;

namespace webapi.Services
{
    public class mongoDbServices
    {
        private IMongoCollection<TodoModel> TodoCollection { get; }

        public mongoDbServices(string databasesName, string collectionName, string databaseUrl)
        {

            //mongodb://mongouds:Jw30tpPIPe_-@den1.mongo1.gear.host:27001/?authSource=mongouds
           IMongoClient client = new MongoClient("mongodb+srv://admin:010203@clustervalotto-c9rs6.mongodb.net/test");
           IMongoDatabase database = client.GetDatabase("test");
           TodoCollection = database.GetCollection<TodoModel>(collectionName);
        }
        // Lista todos os dados da Base
        public async Task <List<TodoModel>> GetAllTodos(){

            var todos = new List<TodoModel>();

            var allDocuments = await TodoCollection.FindAsync(new BsonDocument());

            await allDocuments.ForEachAsync(doc => todos.Add(doc)); return todos; }
        //Grava as informações
        public async Task InsertTodo(TodoModel todo) => await TodoCollection.InsertOneAsync(todo);                 
        //Atualiza os dados
        public async Task Update(TodoModel todo) => await TodoCollection.UpdateOneAsync(Builders<TodoModel>.Filter.Eq("_id", todo.ObjetId), Builders<TodoModel>.Update.Set("Tamanho", todo.Tamanho).Set("Sabor", todo.Sabor).Set("Personalizacao", todo.Personalizacao).Set("Valor_total", todo.Valor_total).Set("Tempo_preparo", todo.Tempo_preparo));  
        //Deleta os dados
        public async Task Delete(TodoModel todo) => await TodoCollection.DeleteOneAsync(Builders<TodoModel>.Filter.Eq("_id", todo.ObjetId));
        
    }
}
