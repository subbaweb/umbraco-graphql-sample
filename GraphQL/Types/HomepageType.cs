namespace UmbracoGraphQLSample.GraphQL.Types;

/// <summary>
/// GraphQL type representing a Homepage from Umbraco
/// </summary>
public class HomepageType
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Title { get; set; }

    public string? Headline { get; set; }

    public string? Description { get; set; }

    public string? HeroImage { get; set; }

    public string? CallToActionText { get; set; }

    public string? CallToActionUrl { get; set; }

    public string? Content { get; set; }

    public List<FeatureType>? Features { get; set; }

    public List<TestimonialType>? Testimonials { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsPublished { get; set; }
}
