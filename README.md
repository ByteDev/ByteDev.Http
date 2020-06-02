[![Build status](https://ci.appveyor.com/api/projects/status/github/bytedev/ByteDev.Http?branch=master&svg=true)](https://ci.appveyor.com/project/bytedev/ByteDev-Http/branch/master)
[![NuGet Package](https://img.shields.io/nuget/v/ByteDev.Http.svg)](https://www.nuget.org/packages/ByteDev.Http)
[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](https://github.com/ByteDev/ByteDev.Http/blob/master/LICENSE)

# ByteDev.Http

.NET Standard library with some HTTP related functionality.

## Installation

ByteDev.Http has been written as a .NET Standard 2.0 library, so you can consume it from a .NET Core or .NET Framework 4.6.1 (or greater) application.

ByteDev.Http is hosted as a package on nuget.org.  To install from the Package Manager Console in Visual Studio run:

`Install-Package ByteDev.Http`

Further details can be found on the [nuget page](https://www.nuget.org/packages/ByteDev.Http/).

## Release Notes

Releases follow semantic versioning.

Full details of the release notes can be viewed on [GitHub](https://github.com/ByteDev/ByteDev.Http/blob/master/docs/RELEASE-NOTES.md).

## Code

The repo can be cloned from git bash:

`git clone https://github.com/ByteDev/ByteDev.Http`

## Usage

Library currently consists of two main classes: `HttpStatusCode` and `MediaType`.

### HttpStatusCode

```csharp
HttpStatusCode statusCode = HttpStatusCode.CreateFromCode(404);

Console.WriteLine(statusCode.Code);                 // 404
Console.WriteLine(statusCode.Name);                 // Not Found
Console.WriteLine(statusCode.Category.Code);        // 4
Console.WriteLine(statusCode.Category.Name);        // Client Error
Console.WriteLine(statusCode.Category.Description); // Request contains bad syntax or cannot be fulfilled.
```

### MediaType

```csharp
var mediaType = new MediaType("application/vnd.api+json; charset=UTF-8");

Console.WriteLine(mediaType);                       // application/vnd.api+json; charset=UTF-8
Console.WriteLine(mediaType.Type);                  // application
Console.WriteLine(mediaType.Tree);                  // vnd
Console.WriteLine(mediaType.SubType);               // api
Console.WriteLine(mediaType.Suffix);                // json
Console.WriteLine(mediaType.Parameters["charset"]); // UTF-8
```

### FormUrlEncodedSerializer

Located in the namespace: `ByteDev.Http.FormUrlEncoded.Serialization`. 

Supports all built .NET basic types (primitives, decimal, string, object etc.).

**Serialize**
```csharp
var obj = new TestDummy
{
    SomeString = "Test String",
    SomeInt = 10
};

var result = FormUrlEncodedSerializer.Serialize(obj);

Console.WriteLine(result);          // "SomeString=Test+String&SomeInt=10"
```

**Deserialize**
```csharp
string data = "SomeString=Test+String&SomeInt=10";

var result = FormUrlEncodedSerializer.Deserialize<TestDummy>(data);

Console.WriteLine(result.SomeString);       // "Test String"
Console.WriteLine(result.SomeInt);          // 10
```