using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoreDocker.Models;
using MongoDB.Bson;


namespace CoreDocker.Services
{
    public class MongodbServices 
    {


        private IMongoCollection<TodoModel> TodoCollection { get; }

        public MongodbServices(string databasesName, string collectionName, string databaseUrl)
        {
            //mongodb://mongouds:Jw30tpPIPe_-@den1.mongo1.gear.host:27001/?authSource=mongouds
            IMongoClient client = new MongoClient("mongodb://mongouds:Jw30tpPIPe_-@den1.mongo1.gear.host:27001/?authSource=mongouds");
            IMongoDatabase database = client.GetDatabase("mongouds");
            TodoCollection = database.GetCollection<TodoModel>(collectionName);
        }
        // Lista todos os dados da Base
        public async Task<List<TodoModel>> GetAllTodos()
        
        {

            // realiza o filtro na lista com o ultimo registro.
            var list = await TodoCollection.Find(FilterDefinition<TodoModel>.Empty).Limit(1).Sort("{_id : -1}").ToListAsync();

            var todos = new List<TodoModel>(list);
            
            ////var items = TodoCollection.Find(x => x.Valor_total == 28).ToList();

            //var allDocuments = await TodoCollection.FindAsync(new BsonDocument());

        
            //await allDocuments.ForEachAsync(doc => todos.Add(doc));  // Lista todos os dados registrado no banco

            //await allDocuments.ForEachAsync(list => todos.Add(list));
            
            return todos;
        }

        internal void InsertTodo(TodoModel todo)
        {

            TodoCollection.InsertOneAsync(todo);
    
        }

        //Grava as informações
       // public void InsertTodo(TodoModel todo) { TodoCollection.InsertOneAsync(todo); }

   
        //Atualiza os dados
        public async Task Update(TodoModel todo) => await TodoCollection.UpdateOneAsync(Builders<TodoModel>.Filter.Eq("_id", todo.ObjetId),
        Builders<TodoModel>.Update.Set("Tamanho", todo.Tamanho).Set("Sabor", todo.Sabor)
       .Set("Personalizacao", todo.Personalizacao).Set("Valor_total", todo.Valor_total).Set("Tempo_preparo", todo.Tempo_preparo));

        //Deleta os dados
        public async Task Delete(TodoModel todo) => await TodoCollection.DeleteOneAsync(Builders<TodoModel>.Filter.Eq("_id", todo.ObjetId));

    }
}
