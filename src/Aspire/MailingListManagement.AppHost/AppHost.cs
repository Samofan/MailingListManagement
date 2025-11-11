var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");

var postgres = builder.AddPostgres("postgres");
var mailingListDb = postgres.AddDatabase("mailing-list-management");

var apiService = builder.AddProject<Projects.MailingListManagement_ApiService>("apiservice")
    .WithHttpHealthCheck("/health")
    .WithReference(cache)
    .WithReference(mailingListDb)
    .WaitFor(mailingListDb)
    .WaitFor(cache);

builder.AddNpmApp("frontend", "../../MailingListManagement.Frontend")
    .WithReference(apiService)
    .WaitFor(apiService)
    .WithHttpEndpoint(env: "PORT")
    .WithExternalHttpEndpoints()
    .PublishAsDockerFile();

builder.Build().Run();
