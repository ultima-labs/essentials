namespace UltimaLabs.CosmosDB.Abstractions
{
    public interface IHaveETag
    {
        string? ETag { get; }
    }
}