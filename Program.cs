using HotChocolate.Execution.Configuration;
using UmbracoGraphQLSample.GraphQL;
using UmbracoGraphQLSample.Services;

var builder = WebApplication.CreateBuilder(args);

// Add HotChocolate GraphQL
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddSubscriptionType<Subscription>()
    .AddProjections()
    .AddFiltering()
    .AddSorting();

// Add custom services
builder.Services.AddScoped<UmbracoContentService>();
builder.Services.AddScoped<GraphQLService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error");
}

// Map GraphQL endpoint
app.MapGraphQL("/graphql");

// Map health check
app.MapGet("/", () => "Umbraco GraphQL Sample - Open https://localhost:5001/graphql");

app.Run();
