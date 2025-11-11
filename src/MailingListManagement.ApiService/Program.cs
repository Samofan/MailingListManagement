using MailingListManagement.ApiService;
using MailingListManagement.ApiService.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddProblemDetails();
builder.Services.AddOpenApi();
builder.Services.AddControllers().AddOData();
builder.Services.AddApiVersioning().AddMvc();
builder.Services.AddSwaggerGen();

builder.AddRedisClient("cache");
builder.Services.AddHybridCache();

builder.AddNpgsqlDbContext<MailingListDbContext>(connectionName: "mailing-list-management");

var app = builder.Build();

app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapDefaultEndpoints();
app.UseRouting();
app.MapControllers();

app.Run();
