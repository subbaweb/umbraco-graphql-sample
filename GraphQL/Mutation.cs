using HotChocolate;
using UmbracoGraphQLSample.GraphQL.Types;
using UmbracoGraphQLSample.Services;

namespace UmbracoGraphQLSample.GraphQL;

/// <summary>
/// Root Mutation type for GraphQL API
/// </summary>
public class Mutation
{
    /// <summary>
    /// Update homepage content
    /// </summary>
    public async Task<UpdateHomepagePayload> UpdateHomepage(
        UpdateHomepageInput input,
        [Service] UmbracoContentService contentService)
    {
        try
        {
            var homepage = await contentService.UpdateHomepageAsync(input);
            return new UpdateHomepagePayload
            {
                Success = true,
                Message = "Homepage updated successfully",
                Homepage = homepage
            };
        }
        catch (Exception ex)
        {
            return new UpdateHomepagePayload
            {
                Success = false,
                Message = $"Error updating homepage: {ex.Message}",
                Homepage = null
            };
        }
    }

    /// <summary>
    /// Publish homepage
    /// </summary>
    public async Task<PublishHomepagePayload> PublishHomepage(
        [Service] UmbracoContentService contentService)
    {
        try
        {
            var homepage = await contentService.PublishHomepageAsync();
            return new PublishHomepagePayload
            {
                Success = true,
                Message = "Homepage published successfully",
                Homepage = homepage
            };
        }
        catch (Exception ex)
        {
            return new PublishHomepagePayload
            {
                Success = false,
                Message = $"Error publishing homepage: {ex.Message}",
                Homepage = null
            };
        }
    }

    /// <summary>
    /// Create a new blog post
    /// </summary>
    public async Task<CreateBlogPostPayload> CreateBlogPost(
        CreateBlogPostInput input,
        [Service] UmbracoContentService contentService)
    {
        try
        {
            var blogPost = await contentService.CreateBlogPostAsync(input);
            return new CreateBlogPostPayload
            {
                Success = true,
                Message = "Blog post created successfully",
                BlogPost = blogPost
            };
        }
        catch (Exception ex)
        {
            return new CreateBlogPostPayload
            {
                Success = false,
                Message = $"Error creating blog post: {ex.Message}",
                BlogPost = null
            };
        }
    }

    /// <summary>
    /// Update an existing blog post
    /// </summary>
    public async Task<UpdateBlogPostPayload> UpdateBlogPost(
        int id,
        UpdateBlogPostInput input,
        [Service] UmbracoContentService contentService)
    {
        try
        {
            var blogPost = await contentService.UpdateBlogPostAsync(id, input);
            return new UpdateBlogPostPayload
            {
                Success = true,
                Message = "Blog post updated successfully",
                BlogPost = blogPost
            };
        }
        catch (Exception ex)
        {
            return new UpdateBlogPostPayload
            {
                Success = false,
                Message = $"Error updating blog post: {ex.Message}",
                BlogPost = null
            };
        }
    }

    /// <summary>
    /// Delete a blog post by ID
    /// </summary>
    public async Task<DeleteBlogPostPayload> DeleteBlogPost(
        int id,
        [Service] UmbracoContentService contentService)
    {
        try
        {
            await contentService.DeleteBlogPostAsync(id);
            return new DeleteBlogPostPayload
            {
                Success = true,
                Message = "Blog post deleted successfully",
                DeletedId = id
            };
        }
        catch (Exception ex)
        {
            return new DeleteBlogPostPayload
            {
                Success = false,
                Message = $"Error deleting blog post: {ex.Message}",
                DeletedId = null
            };
        }
    }

    /// <summary>
    /// Publish a blog post
    /// </summary>
    public async Task<PublishBlogPostPayload> PublishBlogPost(
        int id,
        [Service] UmbracoContentService contentService)
    {
        try
        {
            var blogPost = await contentService.PublishBlogPostAsync(id);
            return new PublishBlogPostPayload
            {
                Success = true,
                Message = "Blog post published successfully",
                BlogPost = blogPost
            };
        }
        catch (Exception ex)
        {
            return new PublishBlogPostPayload
            {
                Success = false,
                Message = $"Error publishing blog post: {ex.Message}",
                BlogPost = null
            };
        }
    }
}

// Input types for Homepage
public class UpdateHomepageInput
{
    public string? Title { get; set; }
    public string? Headline { get; set; }
    public string? Description { get; set; }
    public string? HeroImage { get; set; }
    public string? CallToActionText { get; set; }
    public string? CallToActionUrl { get; set; }
    public string? Content { get; set; }
    public List<UpdateFeatureInput>? Features { get; set; }
    public List<UpdateTestimonialInput>? Testimonials { get; set; }
}

public class UpdateFeatureInput
{
    public int? Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Icon { get; set; }
    public int Order { get; set; }
}

public class UpdateTestimonialInput
{
    public int? Id { get; set; }
    public string? AuthorName { get; set; }
    public string? AuthorTitle { get; set; }
    public string? AuthorImage { get; set; }
    public string? Quote { get; set; }
    public int Rating { get; set; }
    public int Order { get; set; }
}

// Payload types for Homepage
public class UpdateHomepagePayload
{
    public bool Success { get; set; }
    public string? Message { get; set; }
    public HomepageType? Homepage { get; set; }
}

public class PublishHomepagePayload
{
    public bool Success { get; set; }
    public string? Message { get; set; }
    public HomepageType? Homepage { get; set; }
}

// Input types for Blog Posts
public class CreateBlogPostInput
{
    public string? Name { get; set; }
    public string? Content { get; set; }
    public string? Summary { get; set; }
    public DateTime? PublishDate { get; set; }
    public int? AuthorId { get; set; }
    public List<string>? Tags { get; set; }
}

public class UpdateBlogPostInput
{
    public string? Name { get; set; }
    public string? Content { get; set; }
    public string? Summary { get; set; }
    public DateTime? PublishDate { get; set; }
    public int? AuthorId { get; set; }
    public List<string>? Tags { get; set; }
}

// Payload types for Blog Posts
public class CreateBlogPostPayload
{
    public bool Success { get; set; }
    public string? Message { get; set; }
    public BlogPostType? BlogPost { get; set; }
}

public class UpdateBlogPostPayload
{
    public bool Success { get; set; }
    public string? Message { get; set; }
    public BlogPostType? BlogPost { get; set; }
}

public class DeleteBlogPostPayload
{
    public bool Success { get; set; }
    public string? Message { get; set; }
    public int? DeletedId { get; set; }
}

public class PublishBlogPostPayload
{
    public bool Success { get; set; }
    public string? Message { get; set; }
    public BlogPostType? BlogPost { get; set; }
}
