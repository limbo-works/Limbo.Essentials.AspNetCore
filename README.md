# Skybrud.Essentials.AspNetCore

Skybrud.Essentials addon for working with ASP.NET Core.

## Installation

### NuGet

Install via the new .NET CLI:

```
dotnet add package Skybrud.Essentials.AspNetCore --version 1.0.0-alpha001
```

or the older Nuget package manager:

```
Install-Package Skybrud.Essentials.AspNetCore -Version 1.0.0-alpha001
```

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
        {"double", "3.1415926535"},
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
