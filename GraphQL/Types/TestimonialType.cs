namespace UmbracoGraphQLSample.GraphQL.Types;

/// <summary>
/// GraphQL type representing a Testimonial on the homepage
/// </summary>
public class TestimonialType
{
    public int Id { get; set; }

    public string? AuthorName { get; set; }

    public string? AuthorTitle { get; set; }

    public string? AuthorImage { get; set; }

    public string? Quote { get; set; }

    public int Rating { get; set; }

    public int Order { get; set; }
}
