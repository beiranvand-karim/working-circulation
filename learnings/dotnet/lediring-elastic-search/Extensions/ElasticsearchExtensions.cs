using Elastic.Clients.Elasticsearch;
using lediring_elastic_search.Interfaces;
using lediring_elastic_search.Models;
using lediring_elastic_search.Services;

namespace lediring_elastic_search.Extensions;

public static class ElasticsearchExtensions
{
    public static IServiceCollection AddElasticsearch(this IServiceCollection services, IConfiguration configuration)
    {
        var url = configuration["Elasticsearch:Url"]!;
        var indexName = configuration["Elasticsearch:IndexName"]!;

        var settings = new ElasticsearchClientSettings(new Uri(url));
        services.AddSingleton(new ElasticsearchClient(settings));
        services.AddSingleton<IElasticSearchService<User>>(
            sp => new ElasticSearchService<User>(sp.GetRequiredService<ElasticsearchClient>(), indexName));

        return services;
    }
}
