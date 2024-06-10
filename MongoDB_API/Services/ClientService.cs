using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB_API.Models;
using MongoDB_API.Utils;

namespace MongoDB_API.Services
{
    public class ClientService
    {
        private readonly IMongoCollection<Client> _client;
        public ClientService(IMongoDBAPIDataBaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _client = database.GetCollection<Client>(settings.ClientCollectionName);
        }
        public List<Client> Get() => _client.Find(client => true).ToList();
        public Client Get(string id) => _client.Find<Client>(cliente => cliente.Id == id).FirstOrDefault();
        public Client Create(Client client)
        {
            _client.InsertOne(client);
            return client;
        }
        public Client Update(Client client)
        {
            _client.ReplaceOne(x => x.Id == client.Id, client);
            return client;
        }
        public void Delete(string id)
        {
            _client.DeleteOne(x => x.Id == id);
        }
    }
}
