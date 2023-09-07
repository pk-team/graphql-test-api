using API.Configuration;
using API.Mutation;
using API.Query;
using Infrastructure.Context;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// add cors 
builder.Services.AddCors(options => {
    options.AddPolicy("CorsPolicy", builder => builder
        .AllowAnyMethod()
        .AllowAnyHeader()
        .SetIsOriginAllowed((host) => true)
        .AllowCredentials()
    );
});

builder.Services.AddSingleton<AppDbContext>();
builder.Services.AddQueryHandlers();
builder.Services.AddCommandHandlers();

builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>();

WebApplication app = builder.Build();

app.UseCors("CorsPolicy");
app.MapGraphQL();

app.Run();
