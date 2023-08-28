using API.Mutation;
using API.Query;
using Application.Command;
using Application.Query;
using Infrastructure.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<AppDbContext>();
builder.Services.AddScoped<CreatePersonHandler>();
builder.Services.AddScoped<UpdatePersonHandler>();
builder.Services.AddScoped<GetPersonQuery>();
builder.Services.AddScoped<GetPeopleQuery>();

builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>();

var app = builder.Build();


app.MapGraphQL();

app.Run();
