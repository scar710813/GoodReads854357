using System.Diagnostics.CodeAnalysis;

using Bogus;

using GoodReads.Infrastructure.Mongo.Utils;
using GoodReads.Infrastructure.Mongo.Utils.Interfaces;

using Microsoft.Extensions.Options;

namespace GoodReads.Shared.Mocks
{
    [ExcludeFromCodeCoverage]
    public static class MongoMock
    {
        public static IMongoConnection GetMongoConnection()
        {
            return new Faker<IMongoConnection>().CustomInstantiator(f => {
                var options = GetMongoOptions();

                return new MongoConnection(options);
            }).Generate();
        }

        public static IOptions<MongoConnectionOptions> GetMongoOptions(
            string? connectionString = null
        )
        {
            return new Faker<IOptions<MongoConnectionOptions>>()
                .CustomInstantiator(f => (
                    Options.Create(
                        new MongoConnectionOptions
                        {
                            ConnectionString = connectionString ?? "mongodb://localhost:27017/",
                            Schema = "GoodReadsTest",
                            LogTtlDays = 1
                        }
                    )
                ))
                .Generate();
        }
    }
}