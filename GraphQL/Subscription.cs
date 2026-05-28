using HotChocolate.Execution.Processing;
using UmbracoGraphQLSample.GraphQL.Types;

namespace UmbracoGraphQLSample.GraphQL;

/// <summary>
/// Root Subscription type for GraphQL API
/// </summary>
public class Subscription
{
    /// <summary>
    /// Subscribe to blog post updates
    /// </summary>
    [Subscribe]
    public BlogPostType OnBlogPostUpdated(
        [EventMessage] BlogPostType blogPost)
    {
        return blogPost;
    }

    /// <summary>
    /// Subscribe to new blog post creation
    /// </summary>
    [Subscribe]
    public BlogPostType OnBlogPostCreated(
        [EventMessage] BlogPostType blogPost)
    {
        return blogPost;
    }
}
