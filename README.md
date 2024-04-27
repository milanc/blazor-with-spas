# BlazorWithSpas

This repo has Blazor WebApp and two Angular applications.  
It is created to showcase Blazor custom elements, which are as explained in the [documentation](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/js-spa-frameworks?view=aspnetcore-8.0#blazor-custom-elements), "*useful for gradually introducing Razor components into existing projects written in other SPA frameworks*".  

Based on the documentation, I tried to share a Blazor custom element between multiple SPAs.

## Problem
Blazor requires the `base` tag and it's `href` to be set.
Framework files are loaded relative to the `base href`  
Angular also requires `base` tag to be set and when hosted in nested paths, in this case
`/spa1` and `/spa2`, the `base href` has to be set to these paths.

## Requirements
* .net 8  
* node 18.x or greater

## Try it out
Open the `BlazorApp.sln` and start the `BlazorApp`.   
The `BlazorApp.csproj` has an msbuild target
```xml
<Target Name="BuildSpa" BeforeTargets="Build">
``` 
This target runs before every build and does the following:
* restores the npm packages
* builds angular applications
* copies the generated SPAs to BlazorApp's wwwroot folder

Because of this, the first run takes some time.