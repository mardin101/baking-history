# baking-history

A Blazor WebAssembly application that explores the history of baking.

## 🚀 Automatic Deployment to GitHub Pages

This project is automatically deployed to GitHub Pages after every push to the `main` branch. The deployment workflow is defined in `.github/workflows/pages-deploy.yml`.

### How the Deployment Works

1. **Trigger**: The workflow is triggered on every push to the `main` branch
2. **Build**: The .NET SDK (version 10.0.x) is used to restore dependencies and build the Blazor WebAssembly application
3. **Publish**: The application is published in Release mode using `dotnet publish -c Release`
4. **Upload**: The static site content from `release/wwwroot` is uploaded as a GitHub Pages artifact using `actions/upload-pages-artifact@v3`
5. **Deploy**: The artifact is deployed to GitHub Pages using `actions/deploy-pages@v4`
6. **GitHub Pages**: GitHub Pages serves the content directly from the deployment

### Enabling GitHub Pages (First-time Setup)

To enable GitHub Pages for this repository, follow these steps:

1. Go to your repository on GitHub
2. Click on **Settings** (repository settings, not account settings)
3. In the left sidebar, click on **Pages** under the "Code and automation" section
4. Under **Source**, select **GitHub Actions**
5. Wait a few minutes for the deployment to complete after pushing to `main`
6. Your site will be available at: `https://mardin101.github.io/`

**Note**: The deployment uses GitHub's official Pages deployment actions, which is the modern recommended approach for deploying static sites to GitHub Pages.

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
- Ensure **Source** is set to **GitHub Actions**

#### 2. Verify the Workflow Ran Successfully
- Go to **Actions** tab in your repository
- Check that the "Deploy to GitHub Pages" workflow completed without errors
- Review the workflow logs for any build or deployment failures

#### 3. Common Issues for Blazor WebAssembly Apps

**Missing `.nojekyll` file**: GitHub Pages uses Jekyll by default, which ignores directories starting with underscore (like `_framework`). A `.nojekyll` file in the `wwwroot` directory prevents this behavior. This file is already included in the project.

**Incorrect base path**: The `<base href="/" />` in `wwwroot/index.html` is set to deploy the application at the root of the GitHub Pages site.

**Assets not loading**: Check browser console for 404 errors on assets. This usually indicates the base path is incorrect or the `.nojekyll` file is missing.

#### 4. Wait for Deployment
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