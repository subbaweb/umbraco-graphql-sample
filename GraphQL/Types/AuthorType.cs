namespace UmbracoGraphQLSample.GraphQL.Types;

/// <summary>
/// GraphQL type representing an Author in Umbraco
/// </summary>
public class AuthorType
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Bio { get; set; }

    public DateTime? CreatedDate { get; set; }
}
