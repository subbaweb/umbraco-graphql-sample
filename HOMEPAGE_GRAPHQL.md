# Homepage GraphQL API

This document explains how to retrieve homepage fields from Umbraco using GraphQL.

## Homepage Fields

The homepage content type includes the following fields:

| Field | Type | Description |
|-------|------|-------------|
| `id` | Int | Unique identifier |
| `name` | String | Page name in Umbraco |
| `title` | String | Page title (SEO) |
| `headline` | String | Main headline |
| `description` | String | Meta description |
| `heroImage` | String | Hero image URL |
| `callToActionText` | String | CTA button text |
| `callToActionUrl` | String | CTA button URL |
| `content` | String | Rich text content |
| `features` | [Feature] | Array of features |
| `testimonials` | [Testimonial] | Array of testimonials |
| `createdDate` | DateTime | Created date |
| `updatedDate` | DateTime | Last updated date |
| `isPublished` | Boolean | Publication status |

### Feature Fields

| Field | Type | Description |
|-------|------|-------------|
| `id` | Int | Feature ID |
| `title` | String | Feature title |
| `description` | String | Feature description |
| `icon` | String | Icon class or URL |
| `order` | Int | Display order |

### Testimonial Fields

| Field | Type | Description |
|-------|------|-------------|
| `id` | Int | Testimonial ID |
| `authorName` | String | Author name |
| `authorTitle` | String | Author job title |
| `authorImage` | String | Author photo URL |
| `quote` | String | Testimonial text |
| `rating` | Int | Rating (1-5) |
| `order` | Int | Display order |

## GraphQL Queries

### Get Complete Homepage

Retrieve all homepage data including features and testimonials:

```graphql
query {
  homepage {
    id
    name
    title
    headline
    description
    heroImage
    callToActionText
    callToActionUrl
    content
    createdDate
    updatedDate
    isPublished
    features {
      id
      title
      description
      icon
      order
    }
    testimonials {
      id
      authorName
      authorTitle
      authorImage
      quote
      rating
      order
    }
  }
}
```

### Get Homepage Fields Only

Retrieve only the main homepage fields without nested data:

```graphql
query {
  homepageFields {
    title
    headline
    description
    heroImage
    callToActionText
    callToActionUrl
    content
    isPublished
  }
}
```

### Get Homepage Features

Retrieve only the features section:

```graphql
query {
  homepageFeatures {
    id
    title
    description
    icon
    order
  }
}
```

### Get Homepage Testimonials

Retrieve only the testimonials section:

```graphql
query {
  homepageTestimonials {
    id
    authorName
    authorTitle
    authorImage
    quote
    rating
    order
  }
}
```

## GraphQL Mutations

### Update Homepage Content

Update the main homepage fields:

```graphql
mutation {
  updateHomepage(input: {
    title: "Welcome to Our Site"
    headline: "Build Amazing Web Experiences"
    description: "Learn how to use Umbraco and GraphQL together"
    heroImage: "/media/new-hero.jpg"
    callToActionText: "Get Started Now"
    callToActionUrl: "/get-started"
    content: "<p>Updated content here</p>"
  }) {
    success
    message
    homepage {
      id
      title
      isPublished
      updatedDate
    }
  }
}
```

### Update Features

Update homepage features:

```graphql
mutation {
  updateHomepage(input: {
    features: [
      {
        id: 1
        title: "Feature One"
        description: "Description of feature one"
        icon: "icon-star"
        order: 1
      }
      {
        id: 2
        title: "Feature Two"
        description: "Description of feature two"
        icon: "icon-zap"
        order: 2
      }
    ]
  }) {
    success
    message
    homepage {
      features {
        title
        order
      }
    }
  }
}
```

### Update Testimonials

Update homepage testimonials:

```graphql
mutation {
  updateHomepage(input: {
    testimonials: [
      {
        id: 1
        authorName: "John Smith"
        authorTitle: "CEO"
        authorImage: "/media/john.jpg"
        quote: "This is amazing!"
        rating: 5
        order: 1
      }
    ]
  }) {
    success
    message
    homepage {
      testimonials {
        authorName
        quote
      }
    }
  }
}
```

### Publish Homepage

Publish the homepage to make it live:

```graphql
mutation {
  publishHomepage {
    success
    message
    homepage {
      isPublished
      updatedDate
    }
  }
}
```

## Frontend Integration Examples

### React Example

```javascript
const GET_HOMEPAGE = `
  query {
    homepage {
      title
      headline
      description
      heroImage
      callToActionText
      callToActionUrl
      features {
        title
        description
        icon
      }
      testimonials {
        authorName
        authorTitle
        quote
        rating
      }
    }
  }
`;

async function getHomepage() {
  const response = await fetch('https://localhost:5001/graphql', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify({ query: GET_HOMEPAGE })
  });
  
  const { data } = await response.json();
  return data.homepage;
}
```

### JavaScript/Fetch Example

```javascript
const query = `
  query {
    homepage {
      title
      content
      features { title description }
    }
  }
`;

fetch('/graphql', {
  method: 'POST',
  headers: { 'Content-Type': 'application/json' },
  body: JSON.stringify({ query })
})
.then(res => res.json())
.then(data => console.log(data.data.homepage));
```

### Next.js Example

```typescript
// lib/graphql.ts
const query = `
  query {
    homepage {
      title
      headline
      heroImage
      features { title icon order }
    }
  }
`;

export async function getHomepage() {
  const response = await fetch('https://localhost:5001/graphql', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify({ query }),
    next: { revalidate: 60 } // ISR cache
  });
  
  const { data } = await response.json();
  return data.homepage;
}
```

## Important Implementation Notes

All methods in `UmbracoContentService.cs` have TODO comments where you need to implement actual Umbraco content fetching. Example:

```csharp
// TODO: Implement actual Umbraco homepage content fetching
// var contentService = _umbracoContext.Services.ContentService;
// var homepage = contentService.GetRootContent()
//     .FirstOrDefault(c => c.ContentType.Alias == "HomePage");
```

Replace the placeholder implementations with actual Umbraco API calls using:
- `IContentService` - For content operations
- `IMediaService` - For media/images
- `IPublishedContentQuery` - For querying published content
- `IUmbracoContext` - For context access

## Caching Strategy

For production, consider caching homepage data:

```csharp
private readonly IMemoryCache _cache;

public async Task<HomepageType?> GetHomepageAsync()
{
    if (_cache.TryGetValue("homepage", out HomepageType? cached))
    {
        return cached;
    }
    
    // Fetch from Umbraco
    var homepage = await FetchFromUmbracoAsync();
    
    // Cache for 1 hour
    _cache.Set("homepage", homepage, TimeSpan.FromHours(1));
    
    return homepage;
}
```

## Error Handling

All queries include error handling. The mutations return a payload with:
- `success` - Boolean indicating success/failure
- `message` - Human-readable message
- `homepage` - The updated homepage data (if successful)

Example error response:

```json
{
  "data": {
    "updateHomepage": {
      "success": false,
      "message": "Error updating homepage: Field 'title' is required",
      "homepage": null
    }
  }
}
```
