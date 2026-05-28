using HotChocolate.Execution.Configuration;
using Umbraco.Cms.Web.Common.DependencyInjection;
using UmbracoGraphQLSample.GraphQL;
using UmbracoGraphQLSample.Services;

var builder = WebApplicationBuilder.CreateBuilder(args);

// Add Umbraco
builder
    .AddUmbraco(
        new UmbracoBuilder()
            .AddBackOffice()
            .AddWebsite()
            .Build())
    .AddComposers();

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

var app = builder
    .Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error");
}

// Use Umbraco
app.UseUmbraco()
    .WithMiddleware(u =>
    {
        u.UseBackOffice();
        u.UseWebsite();
    })
    .WithEndpoints(u =>
    {
        u.UseBackOfficeEndpoints();
        u.UseWebsiteEndpoints();
    });

// Map GraphQL endpoint
app.MapGraphQL("/graphql");

app.Run();
