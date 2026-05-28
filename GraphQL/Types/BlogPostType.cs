namespace UmbracoGraphQLSample.GraphQL.Types;

/// <summary>
/// GraphQL type representing a Blog Post from Umbraco
/// </summary>
public class BlogPostType
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Content { get; set; }

    public string? Summary { get; set; }

    public DateTime? PublishDate { get; set; }

    public AuthorType? Author { get; set; }

    public List<string>? Tags { get; set; }

    public bool IsPublished { get; set; }
}
