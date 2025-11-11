using MailingListManagement.ApiService;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddProblemDetails();
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.AddRedisClient("cache");
builder.Services.AddHybridCache();

builder.AddNpgsqlDbContext<MailingListDbContext>(connectionName: "mailing-list-management");

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
    // Redirect to swagger in development.
    app.MapGet("/", () => Results.Redirect("/swagger/index.html"));
}

app.MapDefaultEndpoints();
app.UseRouting();
app.UseCors();
app.MapControllers();

app.Run();
