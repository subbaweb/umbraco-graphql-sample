# Umbraco 17 + HotChocolate GraphQL Sample

A complete sample setup demonstrating integration between **Umbraco 17** CMS and **HotChocolate GraphQL** server with a working homepage example.

## Features

- ✅ Umbraco 17 content management
- ✅ HotChocolate GraphQL API
- ✅ Homepage with fields retrieval from Umbraco
- ✅ Features and testimonials sections
- ✅ Query and mutation examples
- ✅ Subscription support
- ✅ VS Code optimized
- ✅ .NET 10 ready

## Prerequisites

- **.NET 10** SDK
- **Visual Studio Code** with C# Dev Kit extension
- SQL Server (LocalDB for local development)

### VS Code Extensions

Install these extensions in VS Code:
1. **C# Dev Kit** - ms-dotnettools.csharp
2. **REST Client** - humao.rest-client (optional)

## Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/subbaweb/umbraco-graphql-sample.git
cd umbraco-graphql-sample
```

### 2. Restore Dependencies

```bash
dotnet restore
```

### 3. Run the Project

```bash
dotnet run
```

Or use VS Code debugging:
- Press `F5` to start with debugger

The application will be available at `https://localhost:5001`

### 4. Access the Application

- **Umbraco Admin**: `https://localhost:5001/umbraco`
- **GraphQL Playground**: `https://localhost:5001/graphql`

## Homepage Example

Get the homepage with all fields from Umbraco:

```graphql
query {
  homepage {
    id
    title
    headline
    description
    heroImage
    callToActionText
    callToActionUrl
    content
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
      quote
      rating
      order
    }
    isPublished
    createdDate
    updatedDate
  }
}
```

## Project Structure

```
├── Models/
│   ├── Content/              # Umbraco content type models
│   └── GraphQL/              # GraphQL types and queries
├── GraphQL/
│   ├── Types/                # HotChocolate GraphQL types
│   │   ├── HomepageType.cs
│   │   ├── FeatureType.cs
│   │   ├── TestimonialType.cs
│   │   ├── BlogPostType.cs
│   │   └── AuthorType.cs
│   ├── Query.cs              # Root query type
│   ├── QueryHomepage.cs      # Homepage queries
│   ├── Mutation.cs           # Root mutation type
│   ├── MutationHomepage.cs   # Homepage mutations
│   └── Subscription.cs       # Root subscription type
├── Services/
│   ├── UmbracoContentService.cs
│   ├── UmbracoContentServiceHomepage.cs
│   └── GraphQLService.cs
├── .vscode/
│   ├── launch.json           # Debug configuration
│   ├── tasks.json            # Build tasks
│   └── settings.json         # Editor settings
├── appsettings.json
├── appsettings.Development.json
├── Program.cs
├── UmbracoGraphQLSample.csproj
├── SETUP_GUIDE.md
├── HOMEPAGE_GRAPHQL.md
├── GRAPHQL_QUERIES.md
└── .gitignore
```

## Available Queries

### Homepage
- `homepage` - Get complete homepage
- `homepageFields` - Get homepage fields only
- `homepageFeatures` - Get features section
- `homepageTestimonials` - Get testimonials section

### Blog Posts
- `blogPosts` - Get all blog posts
- `blogPostById(id)` - Get blog post by ID
- `searchBlogPosts(query)` - Search blog posts

### Authors
- `authors` - Get all authors
- `authorById(id)` - Get author by ID

## Available Mutations

### Homepage
- `updateHomepage(input)` - Update homepage content
- `publishHomepage` - Publish homepage

### Blog Posts
- `createBlogPost(input)` - Create new blog post
- `updateBlogPost(id, input)` - Update blog post
- `deleteBlogPost(id)` - Delete blog post
- `publishBlogPost(id)` - Publish blog post

## Documentation

- **[SETUP_GUIDE.md](./SETUP_GUIDE.md)** - Step-by-step setup instructions
- **[HOMEPAGE_GRAPHQL.md](./HOMEPAGE_GRAPHQL.md)** - Homepage GraphQL API documentation
- **[GRAPHQL_QUERIES.md](./GRAPHQL_QUERIES.md)** - Sample queries and mutations

## Useful Commands

```bash
# Build
dotnet build

# Run
dotnet run

# Watch mode (auto-rebuild)
dotnet watch run

# Clean
dotnet clean

# Publish
dotnet publish -c Release
```

## VS Code Debugging

1. Set breakpoints by clicking line numbers
2. Press `F5` to start debugging
3. Use Debug Console to inspect variables
4. Step through code with `F10` (step over) or `F11` (step into)

## Configuration

### Database Connection

Edit `appsettings.json` to change the connection string:

```json
"ConnectionStrings": {
  "umbracoDbDSN": "Server=(localdb)\\mssqllocaldb;Integrated Security=true;Database=UmbracoGraphQL;Connection Timeout=30;"
}
```

## Implementation Notes

All methods have `TODO` comments showing where to implement actual Umbraco content fetching:

```csharp
// TODO: Implement actual Umbraco content fetching
// var contentService = _umbracoContext.Services.ContentService;
// var homepage = contentService.GetRootContent()
//     .FirstOrDefault(c => c.ContentType.Alias == "HomePage");
```

Replace placeholders with real Umbraco API calls using:
- `IContentService` - Content operations
- `IMediaService` - Media/images
- `IPublishedContentQuery` - Query published content
- `IUmbracoContext` - Context access

## Next Steps

1. **Create Content Types** in Umbraco for HomePage, BlogPost, Author
2. **Implement Resolvers** by replacing TODO sections with actual Umbraco calls
3. **Test Queries** in GraphQL Playground
4. **Build Frontend** using React, Next.js, Vue, etc.
5. **Deploy** to production

## Resources

- [Umbraco 17 Documentation](https://docs.umbraco.com/umbraco-cms/)
- [HotChocolate Documentation](https://chillicream.com/docs/hotchocolate)
- [GraphQL Official Docs](https://graphql.org/)
- [.NET 10 Documentation](https://learn.microsoft.com/dotnet/)

## License

MIT

## Support

For issues or questions:
- Check [GitHub Issues](https://github.com/subbaweb/umbraco-graphql-sample/issues)
- Review error messages and logs
- Check VS Code extension documentation
