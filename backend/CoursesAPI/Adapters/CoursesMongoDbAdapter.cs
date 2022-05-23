using HypertheoryApiUtils;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Events;
using System.Reflection.Metadata;

namespace CoursesAPI.Adapters;

public class CoursesMongoDbAdapter
{
    private readonly IMongoCollection<Course> _documentCollection;
    private readonly ILogger<CoursesMongoDbAdapter> _logger;

    public CoursesMongoDbAdapter(ILogger<CoursesMongoDbAdapter> logger, IOptions<MongoConnectionOptions> options)
    {
        _logger = logger;
        var clientSettings = MongoClientSettings.FromConnectionString(options.Value.ConnectionString);
        if (options.Value.LogCommands)
        {
            clientSettings.ClusterConfigurator = db =>
            {
                db.Subscribe<CommandStartedEvent>(e =>
                {
                    _logger.LogInformation($"Running {e.CommandName} - the command looks like this {e.Command.ToJson()}");
                });
            };
        }
        var conn = new MongoClient(clientSettings);

        var db = conn.GetDatabase(options.Value.Database);

        _documentCollection = db.GetCollection<Course>(options.Value.Collection);

    }

    public IMongoCollection<Course> GetCoursesCollection() => _documentCollection;
}
