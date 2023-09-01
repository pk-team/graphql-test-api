using API.Mutation;
using API.Query;
using Application.Command;
using Application.Query;
using Infrastructure.Context;

var builder = WebApplication.CreateBuilder(args);

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
builder.Services.AddScoped<CreatePersonHandler>();
builder.Services.AddScoped<UpdateUserHandler>();
builder.Services.AddScoped<GetPersonQuery>();
builder.Services.AddScoped<GetPeopleQuery>();

builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>();

var app = builder.Build();

app.UseCors("CorsPolicy");
app.MapGraphQL();

app.Run();
