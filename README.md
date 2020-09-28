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

## Usage

Library currently consists of the following main classes:
- `HttpStatusCode`
- `MediaType`
- `FormUrlEncodedSerializer`

### HttpStatusCode

Represents a standard HTTP status code with extended information.

Located in namespace: `ByteDev.Http`.

```csharp
HttpStatusCode statusCode = HttpStatusCode.CreateFromCode(404);

Console.WriteLine(statusCode.Code);                 // 404
Console.WriteLine(statusCode.Name);                 // "Not Found"
Console.WriteLine(statusCode.Category.Code);        // 4
Console.WriteLine(statusCode.Category.Name);        // "Client Error"
Console.WriteLine(statusCode.Category.Description); // "Request contains bad syntax or cannot be fulfilled."
```

### MediaType

Represents an internet media type. Also known as a Multipurpose Internet Mail Extensions (MIME) type.

Located in namespace: `ByteDev.Http`.

```csharp
var mediaType = new MediaType("application/vnd.api+json; charset=UTF-8");

Console.WriteLine(mediaType);                       // "application/vnd.api+json; charset=UTF-8"
Console.WriteLine(mediaType.Type);                  // "application"
Console.WriteLine(mediaType.Tree);                  // "vnd"
Console.WriteLine(mediaType.SubType);               // "api"
Console.WriteLine(mediaType.Suffix);                // "json"
Console.WriteLine(mediaType.Parameters["charset"]); // "UTF-8"
```

### FormUrlEncodedSerializer

Represents a serializer for form URL encoded (x-www-form-urlencoded) content.

Located in namespace: `ByteDev.Http.FormUrlEncoded.Serialization`. 

Supports:
- All built in .NET basic types (primitives, decimal, string, object etc.)
- Options for switching on and off encoding/decoding of characters through the `SerializeOptions` and `DeserializeOptions` type parameters.
- `FormUrlEncodedPropertyNameAttribute` on properties to override the property name to use when serializing/deserializing

#### Example Usage

```csharp
// Entitiy class (class you want to serialize/deserialize)

public class Dummy
{
    public string Name { get; set; }

    public int Age { get; set; }

    [FormUrlEncodedPropertyName("emailAddress")]
    public string Email { get; set; }
}
```

```csharp
// Serialize an object to a form URL encoded string

var dummy = new Dummy
{
    Name = "John Smith",
    Age = 50,
    Email = "john@somewhere.com"
};

string data = FormUrlEncodedSerializer.Serialize(dummy);

Console.WriteLine(data);   // "Name=John+Smith&Age=50&emailAddress=john%40somewhere.com"
```

```csharp
// Deserialize a form URL encoded string to an object

string data = "Name=John+Smith&Age=50&emailAddress=john%40somewhere.com";

Dummy dummy = FormUrlEncodedSerializer.Deserialize<Dummy>(data);

Console.WriteLine(dummy.Name);    // "John Smith"
Console.WriteLine(dummy.Age);     // 50
Console.WriteLine(dummy.Email);   // "john@somewhere.com"
```