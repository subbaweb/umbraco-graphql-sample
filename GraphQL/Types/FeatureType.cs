namespace UmbracoGraphQLSample.GraphQL.Types;

/// <summary>
/// GraphQL type representing a Feature on the homepage
/// </summary>
public class FeatureType
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? Icon { get; set; }

    public int Order { get; set; }
}
