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
dotnet add package Skybrud.Essentials.AspNetCore --version 1.0.0-alpha009
```

or the older Nuget package manager:

```
Install-Package Skybrud.Essentials.AspNetCore -Version 1.0.0-alpha009
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

```cshtml
@using Microsoft.AspNetCore.Http
@using Microsoft.Extensions.Primitives
@using Skybrud.Essentials.AspNetCore

@{

    IQueryCollection query1 = new QueryCollection(new Dictionary<string, StringValues> {
        {"id", new StringValues("1")},
        {"ids", new StringValues(new []{"1", "2", "3"})},
        {"piAsFloat", "3.14"},
        {"piAsDouble", "3.1415926535"},
        {"flag1", ""},
        {"flag2", "true"}
    });
    
    int idInt = query1.GetInt32("id");
    long idLong = query1.GetInt64("id");
    
    int[] idsInt = query1.GetInt32Array("ids");
    long[] idsLong = query1.GetInt64Array("ids");

    float piFloat = query1.GetFloat("piAsFloat");
    double piDouble = query1.GetDouble("piAsDouble");
    
    bool flag1 = query1.GetBoolean("flag1", true);
    bool flag2 = query1.GetBoolean("flag2", true);
    
    <pre>ID (int): @idInt</pre>
    <pre>ID (long): @idLong</pre>
    
    <pre>IDs (int): @string.Join(", ", idsInt)</pre>
    <pre>IDs (long): @string.Join(", ", idsLong)</pre>

    <pre>PI (float): @piFloat</pre>
    <pre>PI (double): @piDouble</pre>
    
    <pre>Flag1: @flag1</pre>
    <pre>Flag1: @flag2</pre>

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
