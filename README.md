# My First ASP.NET Core Application

An ASP.NET Core app to understand the foundational concepts of Requests, Responses, Headers,
Reverse proxies, Query strings and HTTP methods.

## What I learned
***
> 1. Setting up an IIS Reverse Proxy
> 2. Reading Response headers
> 3. Setting custom Request Headers
> 4. Query String
> 5. GET and POST HTTP Methods
> 6. Testing HTTP methods with Postman
	

## Files I worked with
***
|#| File | Usage |
|---|---|---|
| 1 | launchsettings.json | launchsettings.json is a configuration file in the Properties folder, that defines launch profiles and describes the behavior of the app during development. I used this file to set up Microsoft's IIS Express reverse proxy to have an underlying understanding of how reverse proxies are used in addition to Kestrel (ASP.NET Core default server). |
| 2 | Program.cs | Program.cs is where the app is built and run. In this file, I set custom response headers and read request headers, parsed query strings and request bodies, and also practiced some backend asynchronous programming. |

## Setting up the IIS Express reverse proxy
***

This has to be done manually, and it involves two steps:

**1. Define the `iisSettings` block:**

```json
"iisSettings": {
    "windowsAuthentication": false,
    "anonymousAuthentication": true,
    "iisExpress": {
      "applicationUrl": "http://localhost:19872",
      "sslPort": 0
    }
```

**2. Add an IIS Express profile**, which lets the app run through IIS Express instead of Kestrel:


```json
"IIS Express": {
      "commandName": "IISExpress",
      "launchBrowser": true,
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    }
```