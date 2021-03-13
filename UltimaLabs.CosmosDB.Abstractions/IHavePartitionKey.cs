namespace UltimaLabs.CosmosDB.Abstractions
{
    public interface IHavePartitionKey
    {
        string? PartitionKey { get; }
    }
}