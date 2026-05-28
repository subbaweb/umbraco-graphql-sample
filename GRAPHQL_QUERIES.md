# GraphQL Queries & Mutations

This file contains example GraphQL queries, mutations, and subscriptions for the Umbraco 17 + HotChocolate sample.

## Homepage Queries

### Get Complete Homepage

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
    isPublished
    createdDate
    updatedDate
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

### Get Homepage Fields

```graphql
query {
  homepageFields {
    title
    headline
    description
    content
  }
}
```

### Get Homepage Features

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

```graphql
query {
  homepageTestimonials {
    authorName
    authorTitle
    quote
    rating
    order
  }
}
```

## Blog Post Queries

### Get All Blog Posts

```graphql
query {
  blogPosts {
    id
    name
    content
    summary
    publishDate
    isPublished
    author {
      id
      name
      email
    }
    tags
  }
}
```

### Get Blog Post by ID

```graphql
query {
  blogPostById(id: 1) {
    id
    name
    content
    summary
    publishDate
    isPublished
    author {
      name
      email
      bio
    }
  }
}
```

### Search Blog Posts

```graphql
query {
  searchBlogPosts(query: "umbraco") {
    id
    name
    content
    summary
    publishDate
  }
}
```

## Author Queries

### Get All Authors

```graphql
query {
  authors {
    id
    name
    email
    bio
    createdDate
  }
}
```

### Get Author by ID

```graphql
query {
  authorById(id: 1) {
    id
    name
    email
    bio
  }
}
```

## Homepage Mutations

### Update Homepage

```graphql
mutation {
  updateHomepage(input: {
    title: "Welcome to Our Platform"
    headline: "Start Building Today"
    description: "The easiest way to manage your content"
    heroImage: "/media/hero.jpg"
    callToActionText: "Get Started"
    callToActionUrl: "/signup"
    content: "<p>Your content here</p>"
  }) {
    success
    message
    homepage {
      id
      title
      isPublished
    }
  }
}
```

### Update Homepage Features

```graphql
mutation {
  updateHomepage(input: {
    features: [
      {
        title: "Fast"
        description: "Lightning quick performance"
        icon: "icon-zap"
        order: 1
      }
      {
        title: "Secure"
        description: "Enterprise-grade security"
        icon: "icon-shield"
        order: 2
      }
    ]
  }) {
    success
    homepage {
      features {
        title
        icon
      }
    }
  }
}
```

### Publish Homepage

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

## Blog Post Mutations

### Create Blog Post

```graphql
mutation {
  createBlogPost(input: {
    name: "Getting Started with GraphQL"
    content: "<p>Introduction to GraphQL...</p>"
    summary: "Learn GraphQL basics"
    publishDate: "2026-05-28T10:00:00Z"
    authorId: 1
    tags: ["graphql", "tutorial", "beginner"]
  }) {
    success
    message
    blogPost {
      id
      name
      isPublished
    }
  }
}
```

### Update Blog Post

```graphql
mutation {
  updateBlogPost(id: 1, input: {
    name: "Updated Title"
    content: "<p>Updated content</p>"
    summary: "Updated summary"
    tags: ["updated", "graphql"]
  }) {
    success
    blogPost {
      id
      name
    }
  }
}
```

### Publish Blog Post

```graphql
mutation {
  publishBlogPost(id: 1) {
    success
    blogPost {
      id
      isPublished
      publishDate
    }
  }
}
```

### Delete Blog Post

```graphql
mutation {
  deleteBlogPost(id: 1) {
    success
    message
    deletedId
  }
}
```

## Subscriptions

### Subscribe to Blog Post Updates

```graphql
subscription {
  onBlogPostUpdated {
    id
    name
    content
    publishDate
  }
}
```

### Subscribe to Blog Post Creation

```graphql
subscription {
  onBlogPostCreated {
    id
    name
    content
    author {
      name
    }
  }
}
```

## Testing with GraphQL Playground

1. Open `https://localhost:5001/graphql` in your browser
2. Copy and paste any query/mutation above into the left panel
3. Click the play button or press `Ctrl+Enter`
4. View results in the right panel

## Tips

- Use the "Docs" button (bottom-right) to explore the full schema
- Use "Prettify" to format your queries
- Only request the fields you need
- Use variables for better query organization:

```graphql
query GetBlogPost($id: Int!) {
  blogPostById(id: $id) {
    id
    name
    content
  }
}

# Variables:
# { "id": 1 }
```
