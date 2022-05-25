using HypertheoryApiUtils;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Events;
using RegistrationApi.Domain;
using System.Reflection.Metadata;

namespace RegistrationApi.Adapters;

public class RegistrationsAdapter
{
    private readonly IMongoCollection<Reservation> _documentCollection;
    private readonly ILogger<RegistrationsAdapter> _logger;

    public RegistrationsAdapter(ILogger<RegistrationsAdapter> logger, IOptions<MongoConnectionOptions> options)
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

        _documentCollection = db.GetCollection<Reservation>(options.Value.Collection);

    }

    public IMongoCollection<Reservation> GetDocumentCollection() => _documentCollection;
}
