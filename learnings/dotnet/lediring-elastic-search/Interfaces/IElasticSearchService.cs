namespace lediring_elastic_search.Interfaces;

public interface IElasticSearchService<T> where T : class
{
    Task CreateIndexAsync(string indexName);
    Task IndexAsync(T document);
    Task<T?> GetAsync(string id);
    Task<IEnumerable<T>> SearchAsync(string query);
    Task UpdateAsync(string id, T document);
    Task DeleteAsync(string id);
}
