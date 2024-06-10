namespace MongoDB_API.Utils
{
    public class MongoDBAPIDataBaseSettings : IMongoDBAPIDataBaseSettings
    {
        public string ClientCollectionName { get; set; }
        public string AddressCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
