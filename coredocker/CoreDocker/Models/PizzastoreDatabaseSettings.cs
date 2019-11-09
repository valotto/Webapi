namespace CoreDocker.Models
{
        public class PizzastoreDatabaseSettings : IPizzastoreDatabaseSettings
        {
            public string PizzaCollectionName { get; set; }
            public string ConnectionString { get; set; }
            public string DatabaseName { get; set; }
        }

        public interface IPizzastoreDatabaseSettings
        {
            string PizzaCollectionName { get; set; }
            string ConnectionString { get; set; }
            string DatabaseName { get; set; }
        }

}
