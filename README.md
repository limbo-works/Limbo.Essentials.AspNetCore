# Skybrud.Essentials.AspNetCore [![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE.md) [![NuGet](https://img.shields.io/nuget/vpre/Skybrud.Essentials.AspNetCore.svg)](https://www.nuget.org/packages/Skybrud.Essentials.AspNetCore) [![NuGet](https://img.shields.io/nuget/dt/Skybrud.Essentials.AspNetCore.svg)](https://www.nuget.org/packages/Skybrud.Essentials.AspNetCore)

**Skybrud.Essentials.AspNetCore** is an add-on that builds on top of our [Skybrud.Essentials](https://github.com/skybrud/Skybrud.Essentials) package, and it provides various logic that makes it easier to work with different parts of ASP.NET Core - eg. parsing query strings and reading request headers..

<table>
  <tr>
    <td><strong>License:</strong></td>
    <td><a href="./LICENSE.md"><strong>MIT License</strong></a></td>
  </tr>
  <tr>
    <td><strong>Target Frameworks:</strong></td>
    <td>.NET 5, .NET 6 and .NET 7</td>
  </tr>
</table>

<br /><br />

## Installation

### NuGet

To install the package via [NuGet](https://www.nuget.org/packages/Skybrud.Essentials.AspNetCore), you can use either .NET CLI:

```
dotnet add package Skybrud.Essentials.AspNetCore --version 1.0.0-alpha012
```

or the older Nuget package manager:

```
Install-Package Skybrud.Essentials.AspNetCore -Version 1.0.0-alpha012
```

<br /><br />

## Examples

### Extension methods for `HttpRequest`

```cshtml
@using Microsoft.AspNetCore.Http
@using Skybrud.Essentials.AspNetCore

@inject IHttpContextAccessor HttpContextAccessor

@{

    HttpRequest request = HttpContextAccessor.HttpContext.Request;

    Uri uri = request.GetUri();
    
    <pre>Scheme: @uri.Scheme</pre>
    <pre>Host: @uri.Host</pre>
    <pre>Port: @uri.Port</pre>
    <pre>PathAndQuery: @uri.PathAndQuery</pre>
    <pre>ToString: @uri.ToString()</pre>
    <pre>Authority: @uri.GetLeftPart(UriPartial.Authority)</pre>
    <pre>PathAndQuery: @uri.PathAndQuery</pre>

    <hr />

    <pre>Remote Address: @request.GetRemoteAddress()</pre>
    <pre>Accept Types: @request.GetAcceptTypes()</pre>
    <pre>Accept Encoding: @request.GetAcceptEncoding()</pre>
    <pre>Accept Languages: @request.GetAcceptLanguage()</pre>
    <pre>User Agent: @request.GetUserAgent()</pre>
    <pre>Referrer: @request.GetReferrer()</pre>

}
```

<br /><br />

### Extension methods for `IQueryCollection`

#### Strings

```cshtml
@using Microsoft.AspNetCore.Http
@using Microsoft.Extensions.Primitives
@using Skybrud.Essentials.AspNetCore
@{

    IQueryCollection query = new QueryCollection(new Dictionary<string, StringValues> {
        {"id", new StringValues("1")},
        {"ids", new StringValues(new []{"1", "2", "3"})},
        {"moreIds", new StringValues(new []{"5,6", "7", "8"})}
    });

    // Prints "1"
    string? id = query.GetString("id");
    <pre>@id</pre>

    // Prints "1,2,3"
    string[] ids = query.GetStringArray("ids");
    <pre>@string.Join(",", ids)</pre>

    // Prints "5,6,7,8"
    List<string> moreIds = query.GetStringList("moreIds");
    <pre>@string.Join(",", moreIds)</pre>

    // Prints "'nope' not found"
    if (query.TryGetString("nope", out string? nope)) {
        <pre>@nope</pre>
    } else {
        <pre>'nope' not found.</pre>
    }

}
```

#### Int32

```cshtml
@using Microsoft.AspNetCore.Http
@using Microsoft.Extensions.Primitives
@using Skybrud.Essentials.AspNetCore
@{

    IQueryCollection query = new QueryCollection(new Dictionary<string, StringValues> {
        {"id", new StringValues("1")},
        {"ids", new StringValues(new []{"1", "2", "3"})},
        {"moreIds", new StringValues(new []{"5,6", "7", "8"})}
    });

    // Prints "1"
    int id = query.GetInt32("id");
    <pre>@id</pre>

    // Prints "2" (via fallback)
    int id2 = query.GetInt32("id2", 2);
    <pre>@id2</pre>

    // Prints "" (since null is rendered as empty)
    int? id3 = query.GetInt32OrNull("id3");
    <pre>@id3</pre>

    // Prints "1,2,3"
    int[] ids = query.GetInt32Array("ids");
    <pre>@string.Join(",", ids)</pre>

    // Prints "5,6,7,8"
    List<int> moreIds = query.GetInt32List("moreIds");
    <pre>@string.Join(",", moreIds)</pre>

    // Prints "'nope' not found"
    if (query.TryGetInt32("nope", out int? nope)) {
        <pre>@nope</pre>
    } else {
        <pre>'nope' not found.</pre>
    }

}
```

#### Int64

```cshtml
@using Microsoft.AspNetCore.Http
@using Microsoft.Extensions.Primitives
@using Skybrud.Essentials.AspNetCore
@{

    IQueryCollection query = new QueryCollection(new Dictionary<string, StringValues> {
        {"id", new StringValues("1")},
        {"ids", new StringValues(new []{"1", "2", "3"})},
        {"moreIds", new StringValues(new []{"5,6", "7", "8"})}
    });

    // Prints "1"
    long id = query.GetInt64("id");
    <pre>@id</pre>

    // Prints "2" (via fallback)
    long id2 = query.GetInt64("id2", 2);
    <pre>@id2</pre>

    // Prints "" (since null is rendered as empty)
    long? id3 = query.GetInt64OrNull("id3");
    <pre>@id3</pre>

    // Prints "1,2,3"
    long[] ids = query.GetInt64Array("ids");
    <pre>@string.Join(",", ids)</pre>

    // Prints "5,6,7,8"
    List<long> moreIds = query.GetInt64List("moreIds");
    <pre>@string.Join(",", moreIds)</pre>

    // Prints "'nope' not found"
    if (query.TryGetInt64("nope", out long? nope)) {
        <pre>@nope</pre>
    } else {
        <pre>'nope' not found.</pre>
    }

}
```

#### Float

```cshtml
@using Microsoft.AspNetCore.Http
@using Microsoft.Extensions.Primitives
@using Skybrud.Essentials.AspNetCore
@{

    IQueryCollection query = new QueryCollection(new Dictionary<string, StringValues> {
        {"pi", new StringValues("3.14")},
        {"values", new StringValues(new []{"3.14", "6.28", "9.42"})},
        {"otherValues", new StringValues(new []{"3.14,6.28", "9.42"})}
    });

    // Prints "3.14"
    float pi = query.GetFloat("pi");
    <pre>@pi</pre>

    // Prints "1.23" (via fallback)
    float meh = query.GetFloat("meh", 1.23f);
    <pre>@meh</pre>

    // Prints "" (since null is rendered as empty)
    float? meh2 = query.GetFloatOrNull("meh");
    <pre>@meh2</pre>

    // Prints "3.14,6.28,9.42"
    float[] values = query.GetFloatArray("values");
    <pre>@string.Join(",", values)</pre>

    // Prints "3.14,6.28,9.42"
    List<float> otherValues = query.GetFloatList("otherValues");
    <pre>@string.Join(",", otherValues)</pre>

    // Prints "'nope' not found"
    if (query.TryGetFloat("nope", out float? nope)) {
        <pre>@nope</pre>
    } else {
        <pre>'nope' not found.</pre>
    }

}
```

#### Double

```cshtml
@using Microsoft.AspNetCore.Http
@using Microsoft.Extensions.Primitives
@using Skybrud.Essentials.AspNetCore
@{

    IQueryCollection query = new QueryCollection(new Dictionary<string, StringValues> {
        {"pi", new StringValues("3.1415926535")},
        {"values", new StringValues(new []{"3.1415926535", "6.283185307", "9.4247779605"})},
        {"otherValues", new StringValues(new []{"3.1415926535,6.283185307", "9.4247779605"})}
    });

    // Prints "3.1415926535"
    double pi = query.GetDouble("pi");
    <pre>@pi</pre>

    // Prints "1.23" (via fallback)
    double meh = query.GetDouble("meh", 1.23);
    <pre>@meh</pre>

    // Prints "" (since null is rendered as empty)
    double? meh2 = query.GetDoubleOrNull("meh");
    <pre>@meh2</pre>

    // Prints "3.1415926535,6.283185307,9.4247779605"
    double[] values = query.GetDoubleArray("values");
    <pre>@string.Join(",", values)</pre>

    // Prints "3.1415926535,6.283185307,9.4247779605"
    List<double> otherValues = query.GetDoubleList("otherValues");
    <pre>@string.Join(",", otherValues)</pre>

    // Prints "'nope' not found"
    if (query.TryGetDouble("nope", out double? nope)) {
        <pre>@nope</pre>
    } else {
        <pre>'nope' not found.</pre>
    }

}
```

#### Boolean

```cshtml
@using Microsoft.AspNetCore.Http
@using Microsoft.Extensions.Primitives
@using Skybrud.Essentials.AspNetCore
@{

    IQueryCollection query = new QueryCollection(new Dictionary<string, StringValues> {
        {"a", new StringValues("true")},
        {"b", new StringValues("1")}
    });

    // Prints "True"
    bool a = query.GetBoolean("a");
    <pre>@a</pre>

    // Prints "True"
    bool b = query.GetBoolean("b");
    <pre>@b</pre>

    // Prints "False"
    bool c = query.GetBoolean("c");
    <pre>@c</pre>

    // Prints "True" (via fallback)
    bool d = query.GetBoolean("d", true);
    <pre>@d</pre>

    // Prints "" (since null is rendered as empty)
    bool? e = query.GetBooleanOrNull("e");
    <pre>@e</pre>

    // Prints "'nope' not found"
    if (query.TryGetBoolean("nope", out bool? nope)) {
        <pre>@nope</pre>
    } else {
        <pre>'nope' not found.</pre>
    }

}
```

<br /><br />

### Forcing API controllers to use Newtonsoft.Json

By default, ASP.NET Core uses the logic within the `System.Text.Json` namespace to serialize models to JSON. If you wish to use the `Newtonsoft.Json` package instead, there are a few different approaches for doing so:

#### Use the `Microsoft.AspNetCore.Mvc.NewtonsoftJson` package

This package let's you set up all your API controllers to use `Newtonsoft.Json` for serializing JSON. This is a global setting, so be aware that this may affect parts of your application that it shouldn't.

You don't need `Skybrud.Essentials.AspNetCore` when using this approach.


#### Use the `NewtonsoftJsonResult` class

As an alternative to enabling the use of `Newtonsoft.Json` globally, you can use the `NewtonsoftJsonResult` class from this package. This let's you determine the output an method level - eg. have a controller where some methods use the default `System.Text.Json`, but where others use `Newtonsoft.Json`.

This `NewtonsoftJsonResult` extends ASP.NET Core's `ContentResult` class, and serves as a wrapper for your response body. You may use the `NewtonsoftJsonResult` constructor directly, which then let's you specify a HTTP status code and a value representing your response body. But the class also features a number of static methods for creating a new response with a specific status code:
 
```csharp
public ActionResult Hello() {
    return NewtonsoftJsonResult.Ok(new { yay = true } );
}
```

```csharp
public ActionResult OhNoes() {
  return NewtonsoftJsonResult.InternalError("The server made a boo boo.");
}
```

The `NewtonsoftJsonResult.Ok` and `NewtonsoftJsonResult.Created` methods are used for creating successful responses, so they both take a single parameter representing the response body.

On the other hand, the `NewtonsoftJsonResult.BadRequest`, `NewtonsoftJsonResult.Unauthorized`, `NewtonsoftJsonResult.Forbidden`, `NewtonsoftJsonResult.NotFound` and `NewtonsoftJsonResult.InternalError` represent responsens wrapping an error, so they take a single string parameter with an error message.

For instance, the `NewtonsoftJsonResult.InternalError("The server made a boo boo.")` from before will result in a response with a 500 status code and the following JSON body:

```json
{
  "meta": {
    "code": 500,
    "error": "The server made a boo boo."
  }
}
```

#### Use `NewtonsoftJsonOnlyConfigurationAttribute` on the controller

If you wish to set this up at the controller level, you can add the `NewtonsoftJsonOnlyConfigurationAttribute` to your API controller:

```csharp
[NewtonsoftJsonOnlyConfiguration]
public class MyController : Controller {

    public ActionResult Hello() {
        return new { yay = true };
    }

}
```
