using HotChocolate;
using UmbracoGraphQLSample.GraphQL.Types;
using UmbracoGraphQLSample.Services;

namespace UmbracoGraphQLSample.GraphQL;

/// <summary>
/// Root Query type for GraphQL API
/// </summary>
public class Query
{
    /// <summary>
    /// Get the homepage content from Umbraco
    /// </summary>
    public async Task<HomepageType?> GetHomepage(
        [Service] UmbracoContentService contentService)
    {
        return await contentService.GetHomepageAsync();
    }

    /// <summary>
    /// Get homepage fields/properties
    /// </summary>
    public async Task<HomepageType?> GetHomepageFields(
        [Service] UmbracoContentService contentService)
    {
        return await contentService.GetHomepageFieldsAsync();
    }

    /// <summary>
    /// Get features from homepage
    /// </summary>
    public async Task<List<FeatureType>> GetHomepageFeatures(
        [Service] UmbracoContentService contentService)
    {
        return await contentService.GetHomepageFeaturesAsync();
    }

    /// <summary>
    /// Get testimonials from homepage
    /// </summary>
    public async Task<List<TestimonialType>> GetHomepageTestimonials(
        [Service] UmbracoContentService contentService)
    {
        return await contentService.GetHomepageTestimonialsAsync();
    }

    /// <summary>
    /// Get all blog posts
    /// </summary>
    public async Task<List<BlogPostType>> GetBlogPosts(
        [Service] UmbracoContentService contentService)
    {
        return await contentService.GetBlogPostsAsync();
    }

    /// <summary>
    /// Get a specific blog post by ID
    /// </summary>
    public async Task<BlogPostType?> GetBlogPostById(
        int id,
        [Service] UmbracoContentService contentService)
    {
        return await contentService.GetBlogPostByIdAsync(id);
    }

    /// <summary>
    /// Get all authors
    /// </summary>
    public async Task<List<AuthorType>> GetAuthors(
        [Service] UmbracoContentService contentService)
    {
        return await contentService.GetAuthorsAsync();
    }

    /// <summary>
    /// Get a specific author by ID
    /// </summary>
    public async Task<AuthorType?> GetAuthorById(
        int id,
        [Service] UmbracoContentService contentService)
    {
        return await contentService.GetAuthorByIdAsync(id);
    }

    /// <summary>
    /// Search blog posts by title or content
    /// </summary>
    public async Task<List<BlogPostType>> SearchBlogPosts(
        string query,
        [Service] UmbracoContentService contentService)
    {
        return await contentService.SearchBlogPostsAsync(query);
    }
}
