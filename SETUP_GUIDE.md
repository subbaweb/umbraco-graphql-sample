# Setup Guide for Umbraco 17 + HotChocolate GraphQL

A step-by-step guide to set up and run the Umbraco 17 + HotChocolate GraphQL sample project with a working homepage example.

## Prerequisites

Before you begin, ensure you have the following installed:

- **.NET 10 SDK** - [Download](https://dotnet.microsoft.com/download)
- **Visual Studio Code** - [Download](https://code.visualstudio.com/)
- **SQL Server LocalDB** - Comes with Visual Studio or [Download](https://learn.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb)
- **Git** - [Download](https://git-scm.com/)

## Step 1: Install VS Code Extensions

Open VS Code and install these extensions:

1. **C# Dev Kit** by Microsoft (ms-dotnettools.csharp)
2. **REST Client** by Huachao Mao (humao.rest-client) - optional but useful

In VS Code:
- Press `Ctrl+Shift+X` (or `Cmd+Shift+X` on Mac)
- Search for each extension
- Click "Install"

## Step 2: Clone the Repository

```bash
git clone https://github.com/subbaweb/umbraco-graphql-sample.git
cd umbraco-graphql-sample
```

## Step 3: Open in VS Code

```bash
code .
```

VS Code will automatically detect the C# project and offer to install recommended extensions. Accept these suggestions.

## Step 4: Restore Dependencies

In the VS Code terminal (`Ctrl+~`), run:

```bash
dotnet restore
```

This downloads all NuGet packages required by the project.

## Step 5: Build the Project

```bash
dotnet build
```

You should see a "Build succeeded" message.

## Step 6: Run the Project

```bash
dotnet run
```

Or use VS Code's built-in debugging:
- Press `F5` to start with debugger

The application will start and display output like:

```
Now listening on: https://localhost:5001
```

## Step 7: Access the Application

### Umbraco Admin Panel
- URL: `https://localhost:5001/umbraco`
- This is where you create and manage content types

### GraphQL Playground
- URL: `https://localhost:5001/graphql`
- This is where you write and test GraphQL queries

## Step 8: Test Homepage GraphQL Query

1. Open `https://localhost:5001/graphql` in your browser
2. In the left panel, paste this query:

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
      quote
      rating
      order
    }
  }
}
```

3. Click the "Play" button
4. You should see sample homepage data in the right panel

## Step 9: Create Your Content Types in Umbraco (Optional)

1. Go to `https://localhost:5001/umbraco`
2. Navigate to **Settings** → **Content Types**
3. Create a new content type called "HomePage"
4. Add properties:
   - `title` (Text String)
   - `headline` (Text String)
   - `description` (Text String)
   - `heroImage` (Media Picker)
   - `content` (Rich Text Editor)
   - `callToActionText` (Text String)
   - `callToActionUrl` (Text String)

## Debugging in VS Code

### Set Breakpoints
- Click on the line number in the editor
- A red dot appears
- When the code executes that line, execution pauses

### Step Through Code
- Use toolbar buttons or keyboard shortcuts:
  - `F10` - Step over
  - `F11` - Step into
  - `Shift+F11` - Step out

### View Variables
- Hover over a variable to see its value
- Use the "Variables" panel in the Debug sidebar

## Useful Commands

```bash
# Build the project
dotnet build

# Run the project
dotnet run

# Watch mode (rebuilds on file changes)
dotnet watch run

# Run tests
dotnet test

# Clean build artifacts
dotnet clean

# Publish for production
dotnet publish -c Release
```

## Troubleshooting

### "Project not found"
- Make sure you're in the correct directory
- Run `dotnet sln list` to see available projects

### "Port 5001 already in use"
- The port is occupied by another process
- Run on a different port: `dotnet run --urls https://localhost:5002`

### Database connection errors
- Check `appsettings.json` for correct connection string
- Ensure LocalDB is installed: `sqllocaldb info`
- Create instance if needed: `sqllocaldb create MSSQLLocalDB`

### IntelliSense not working
- Reload VS Code: `Ctrl+K Ctrl+R`
- Restart C# Dev Kit: `Ctrl+Shift+P` → "Developer: Reload Window"

### Umbraco installer not loading
- Clear browser cache: `Ctrl+Shift+Delete`
- Try incognito/private mode
- Check browser console for errors

## Next Steps

1. **Replace TODO implementations** - Add actual Umbraco content fetching
2. **Create Content** - Add homepage and other content in Umbraco
3. **Test Queries** - Use GraphQL Playground to query your content
4. **Build Frontend** - Create a React/Next.js/Vue app using the API
5. **Deploy** - Follow [Umbraco deployment guide](https://docs.umbraco.com/umbraco-cms/fundamentals/setup/install/running-umbraco-on-a-live-server)

## Additional Resources

- [Umbraco 17 Documentation](https://docs.umbraco.com/umbraco-cms/)
- [HotChocolate GraphQL Documentation](https://chillicream.com/docs/hotchocolate)
- [GraphQL Official Documentation](https://graphql.org/)
- [.NET 10 Documentation](https://learn.microsoft.com/dotnet/)

## Getting Help

- Check the [GitHub Issues](https://github.com/subbaweb/umbraco-graphql-sample/issues)
- Review error messages carefully - they often indicate the solution
- Use the VS Code extension documentation
- Ask in relevant communities (Umbraco Forum, GraphQL Slack)
