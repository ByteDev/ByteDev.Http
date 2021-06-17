[![Build status](https://ci.appveyor.com/api/projects/status/github/bytedev/ByteDev.Http?branch=master&svg=true)](https://ci.appveyor.com/project/bytedev/ByteDev-Http/branch/master)
[![NuGet Package](https://img.shields.io/nuget/v/ByteDev.Http.svg)](https://www.nuget.org/packages/ByteDev.Http)
[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](https://github.com/ByteDev/ByteDev.Http/blob/master/LICENSE)

# ByteDev.Http

.NET Standard library with some HTTP related functionality.

Looking for the form URL encoded functionality? It has now moved to a new project [ByteDev.FormUrlEncoded](https://github.com/ByteDev/ByteDev.FormUrlEncoded) which is also on [nuget](https://www.nuget.org/packages/ByteDev.FormUrlEncoded/).

## Installation

ByteDev.Http has been written as a .NET Standard 2.0 library, so you can consume it from a .NET Core or .NET Framework 4.6.1 (or greater) application.

ByteDev.Http is hosted as a package on nuget.org.  To install from the Package Manager Console in Visual Studio run:

`Install-Package ByteDev.Http`

Further details can be found on the [nuget page](https://www.nuget.org/packages/ByteDev.Http/).

## Release Notes

Releases follow semantic versioning.

Full details of the release notes can be viewed on [GitHub](https://github.com/ByteDev/ByteDev.Http/blob/master/docs/RELEASE-NOTES.md).

## Usage

Library currently consists of the following main classes:

- `HttpStatusCode`
- `MediaType`

As well as a few HTTP content specialized classes (located in namespace: `ByteDev.Http.Content`):

- `FormUrlEncodedContent`
- `JsonContent`
- `XmlContent`

---

### HttpStatusCode

Represents a standard HTTP status code with extended information.

Located in namespace: `ByteDev.Http`.

```csharp
HttpStatusCode statusCode = HttpStatusCode.CreateFromCode(404);

// statusCode.Code == 404
// statusCode.Name == "Not Found"
// statusCode.Category.Code == 4
// statusCode.Category.Name == "Client Error"
// statusCode.Category.Description == "Request contains bad syntax or cannot be fulfilled."
```

---

### MediaType

Represents an internet media type. Also known as a Multipurpose Internet Mail Extensions (MIME) type.

Located in namespace: `ByteDev.Http`.

```csharp
var mediaType = new MediaType("application/vnd.api+json; charset=UTF-8");

// mediaType == "application/vnd.api+json; charset=UTF-8"
// mediaType.Type == "application"
// mediaType.Tree == "vnd"
// mediaType.SubType == "api"
// mediaType.Suffix == "json"
// mediaType.Parameters["charset"] == "UTF-8"
```

---

### Extension Methods

The assembly also contains a number of public extension methods.  To use them reference namespace: `ByteDev.Http`.

HttpContent
- ReadAsJsonAsync
- ReadAsXmlAsync

HttpContentHeaders
- AddOrUpdate
