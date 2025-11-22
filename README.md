# baking-history

A Blazor WebAssembly application that explores the history of baking.

## 🚀 Automatic Deployment to GitHub Pages

This project is automatically deployed to GitHub Pages after every push to the `main` branch. The deployment workflow is defined in `.github/workflows/pages-deploy.yml`.

### How the Deployment Works

1. **Trigger**: The workflow is triggered on every push to the `main` branch
2. **Build**: The .NET SDK (version 10.0.x) is used to restore dependencies and build the Blazor WebAssembly application
3. **Publish**: The application is published in Release mode using `dotnet publish -c Release`
4. **Deploy**: The static site content from `bin/Release/net10.0/publish/wwwroot` is pushed to the `gh-pages` branch using [peaceiris/actions-gh-pages](https://github.com/peaceiris/actions-gh-pages)
5. **GitHub Pages**: GitHub Pages serves the content from the `gh-pages` branch

### Enabling GitHub Pages (First-time Setup)

To enable GitHub Pages for this repository, follow these steps:

1. Go to your repository on GitHub
2. Click on **Settings** (repository settings, not account settings)
3. In the left sidebar, click on **Pages** under the "Code and automation" section
4. Under **Source**, select **Deploy from a branch**
5. Under **Branch**, select `gh-pages` and `/ (root)`, then click **Save**
6. Wait a few minutes for the deployment to complete
7. Your site will be available at: `https://mardin101.github.io/baking-history/`

**Note**: The `gh-pages` branch will be created automatically by the GitHub Actions workflow on the first deployment. You may need to trigger the workflow by pushing a commit to `main` before the branch appears in the branch selector.

### Manual Deployment

If you need to deploy manually, you can:

1. Build and publish the application locally:
   ```bash
   dotnet publish -c Release
   ```

2. The static site content will be in `bin/Release/net10.0/publish/wwwroot`

### Troubleshooting GitHub Pages Deployment

If your GitHub Pages site returns a **404 Not Found** error, check the following:

#### 1. Verify GitHub Pages is Enabled
- Go to **Settings > Pages** in your repository
- Ensure **Source** is set to **Deploy from a branch**
- Ensure **Branch** is set to `gh-pages` and `/ (root)`

#### 2. Check the `gh-pages` Branch Exists
- The `gh-pages` branch is created automatically on the first deployment
- Push a commit to `main` to trigger the workflow if the branch doesn't exist yet

#### 3. Verify the Workflow Ran Successfully
- Go to **Actions** tab in your repository
- Check that the "Deploy to GitHub Pages" workflow completed without errors
- Review the workflow logs for any build or deployment failures

#### 4. Common Issues for Blazor WebAssembly Apps

**Missing `.nojekyll` file**: GitHub Pages uses Jekyll by default, which ignores directories starting with underscore (like `_framework`). A `.nojekyll` file in the `wwwroot` directory prevents this behavior. This file is already included in the project.

**Incorrect base path**: The `<base href="/baking-history/" />` in `wwwroot/index.html` must match your repository name for routing to work correctly.

**Assets not loading**: Check browser console for 404 errors on assets. This usually indicates the base path is incorrect or the `.nojekyll` file is missing.

#### 5. Wait for Deployment
After pushing to `main`, it may take 2-5 minutes for the site to be available. Check the Actions tab to see when the deployment completes.

### Related Issues

- [Issue #2: Deploy to GitHub Pages](https://github.com/mardin101/baking-history/issues/2)

## Development

### Prerequisites

- [.NET 10.0 SDK](https://dotnet.microsoft.com/download) or later

### Running Locally

```bash
dotnet restore
dotnet run
```

The application will be available at `https://localhost:5001` (or the port shown in the console).