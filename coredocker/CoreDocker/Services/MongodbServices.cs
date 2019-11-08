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


        private readonly IMongoCollection<TodoModel> TodoCollection;

        public MongodbServices(IPizzastoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            TodoCollection = database.GetCollection<TodoModel>(settings.BooksCollectionName);
        }


        //public List<TodoModel> Get() =>
        //    TodoCollection.Find(s => true).ToList();

        public List<TodoModel> Get() =>TodoCollection.Find(FilterDefinition<TodoModel>.Empty).Limit(1).Sort("{_id : -1}").ToList();




        public TodoModel Create(TodoModel pedido)
        {
            TodoCollection.InsertOne(pedido);
            return pedido;
        }


        //private readonly IMongoCollection<BaseConn> TodoCollection;
        //private readonly IMongoCollection<TodoModel> TodoCollection;



        ////private IMongoCollection<TodoModel> TodoCollection { get; }

        //// public MongodbServices(string databasesName, string collectionName, string databaseUrl)

        //public MongodbServices(BookstoreDatabaseSettings settings)
        //{
        //    //mongodb://mongouds:Jw30tpPIPe_-@den1.mongo1.gear.host:27001/?authSource=mongouds


        //    var client = new MongoClient(settings.ConnectionString);
        //    var database = client.GetDatabase(settings.DatabaseName);

        //    TodoCollection = database.GetCollection<TodoModel>(settings.BooksCollectionName);


        //    //IMongoClient client = new MongoClient("mongodb://mongouds:Jw30tpPIPe_-@den1.mongo1.gear.host:27001/?authSource=mongouds");
        //    // IMongoClient client = new MongoClient(settings.ConnectionString);***********

        //    //IMongoDatabase database = client.GetDatabase("mongouds");
        //    //IMongoDatabase database = client.GetDatabase(settings.DatabaseMongo); ***************


        //    //TodoCollection = database.GetCollection<TodoModel>(collectionName);

        //    //TodoCollection = database.GetCollection<TodoModel>(settings.PizzaCollection);************


        //}



        //// Lista todos os dados da Base
        //public async Task<List<TodoModel>> GetAllTodos()

        //{

        //    // realiza o filtro na lista com o ultimo registro.


        //    //var list = await TodoCollection.Find(FilterDefinition<TodoModel>.Empty).Limit(1).Sort("{_id : -1}").ToListAsync();


        //    var list = await TodoCollection.Find(FilterDefinition<BaseConn>.Empty).Limit(1).Sort("{_id : -1}").ToListAsync();

        //    var todos = new List<BaseConn>(list);


        //    //var allDocuments = await TodoCollection.FindAsync(new BsonDocument());


        //    //await allDocuments.ForEachAsync(doc => todos.Add(doc));  // Lista todos os dados registrado no banco

        //    //await allDocuments.ForEachAsync(list => todos.Add(list));


        //    return List<BaseConn> = todos;

        //}


        //Grava as informações
        // public void InsertTodo(TodoModel todo) { TodoCollection.InsertOneAsync(todo); }


        //Atualiza os dados
        //public async Task Update(TodoModel todo) => await TodoCollection.UpdateOneAsync(Builders<TodoModel>.Filter.Eq("_id", todo.ObjetId),
        //Builders<TodoModel>.Update.Set("Tamanho", todo.Tamanho).Set("Sabor", todo.Sabor)
        //.Set("Personalizacao", todo.Personalizacao).Set("Valor_total", todo.Valor_total).Set("Tempo_preparo", todo.Tempo_preparo));

        //Deleta os dados
        // public async Task Delete(TodoModel todo) => await TodoCollection.DeleteOneAsync(Builders<TodoModel>.Filter.Eq("_id", todo.ObjetId));

    }
}
