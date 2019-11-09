using MongoDB.Driver;
using System.Collections.Generic;
using CoreDocker.Models;

namespace CoreDocker.Services
{
    public class MongodbServices 
    {
        private readonly IMongoCollection<TodoModel> TodoCollection;

        public MongodbServices(IPizzastoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            TodoCollection = database.GetCollection<TodoModel>(settings.PizzaCollectionName);
        }

        public List<TodoModel> Get() => TodoCollection.Find(FilterDefinition<TodoModel>.Empty).Limit(1).Sort("{_id : -1}").ToList();

        public TodoModel Create(TodoModel pedido)
        {
            TodoCollection.InsertOne(pedido);
            return pedido;
        }

    }
}
