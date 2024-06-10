namespace MongoDB_API.Utils
{
    public interface IMongoDBAPIDataBaseSettings
    {
        string ClientCollectionName {  get; set; }
        string AddressCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
