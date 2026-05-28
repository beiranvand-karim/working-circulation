using Elastic.Clients.Elasticsearch;
using Elastic.Clients.Elasticsearch.QueryDsl;
using lediring_elastic_search.Interfaces;

namespace lediring_elastic_search.Services;

public class ElasticSearchService<T>(ElasticsearchClient client, string indexName) : IElasticSearchService<T> where T : class
{
    public async Task CreateIndexAsync(string indexName)
    {
        var exists = await client.Indices.ExistsAsync((Indices)indexName);
        if (exists.IsValidResponse) return;

        var response = await client.Indices.CreateAsync((IndexName)indexName);
        if (!response.IsValidResponse)
            throw new Exception($"Failed to create index '{indexName}': {response.DebugInformation}");
    }

    public async Task IndexAsync(T document)
    {
        var response = await client.IndexAsync(document, (IndexName)indexName);
        if (!response.IsValidResponse)
            throw new Exception($"Failed to index document: {response.DebugInformation}");
    }

    public async Task<T?> GetAsync(string id)
    {
        var response = await client.GetAsync<T>((IndexName)indexName, (Id)id);
        if (!response.IsValidResponse && !response.Found)
            throw new Exception($"Failed to get document '{id}': {response.DebugInformation}");

        return response.Found ? response.Source : null;
    }

    public async Task<IEnumerable<T>> SearchAsync(string query)
    {
        var response = await client.SearchAsync<T>(s => s
            .Indices(indexName)
            .Query(q => q
                .MultiMatch(m => m
                    .Query(query)
                    .Type(TextQueryType.BestFields))));

        if (!response.IsValidResponse)
            throw new Exception($"Search failed: {response.DebugInformation}");

        return response.Documents;
    }

    public async Task UpdateAsync(string id, T document)
    {
        var response = await client.UpdateAsync<T, T>((IndexName)indexName, (Id)id, u => u.Doc(document));
        if (!response.IsValidResponse)
            throw new Exception($"Failed to update document '{id}': {response.DebugInformation}");
    }

    public async Task DeleteAsync(string id)
    {
        var response = await client.DeleteAsync((IndexName)indexName, (Id)id);
        if (!response.IsValidResponse)
            throw new Exception($"Failed to delete document '{id}': {response.DebugInformation}");
    }
}
