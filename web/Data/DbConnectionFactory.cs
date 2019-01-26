using MongoDB.Driver;

namespace Entrusted.Web.Data
{
    public class DbConnectionFactory
    {
        public MongoClient MongoClient { get; private set; }

        public DbConnectionFactory(string connectionString)
        {
            if (MongoClient == null)
            {
                MongoClient = new MongoClient(connectionString);
            }
        }
    }    
}
