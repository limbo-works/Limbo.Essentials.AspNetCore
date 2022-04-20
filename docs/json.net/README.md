# JSON.net

## JsonNetResult

By default, if you return a model from an API controller, the model will be serialized using Microsoft.Text.Json.

If you wish to use JSON.net for serialization instead, you can use the `Skybrud.Essentials.AspNetCore.Models.Json.JsonNetResult` class to wrap your models.

The `Skybrud.Essentials.AspNetCore.Models.Json.JsonNetResult` class features a number of static initializers for the most common status codes:

### 200 OK

```csharp
return JsonNetResult.Ok(new { hello = "world" });
```

returns:

```json
{
    "hello": "world"
}
```

### 201 Created

```csharp
return JsonNetResult.Created(new { hello = "world" });
```

returns:

```json
{
    "hello": "world"
}
```

### 400 Bad Request

```csharp
return JsonNetResult.BadRequest("Nope");
```

returns:

```json
{
    "meta": {
        "code": 400,
        "error": "Nope"
    }
}
```

### 401 Unauthorized

```csharp
return JsonNetResult.Unauthorized("Not authorized");
```

returns:

```json
{
    "meta": {
        "code": 401,
        "error": "Not authorized"
    }
}
```

### 403 Forbidden

```csharp
return JsonNetResult.Forbidden("Forbidden");
```

returns:

```json
{
    "meta": {
        "code": 403,
        "error": "Forbidden"
    }
}
```

### 404 Not Found

```csharp
return JsonNetResult.NotFound("Not Found");
```

returns:

```json
{
    "meta": {
        "code": 404,
        "error": "Not Found"
    }
}
```

### 500 Internal Server Error

```csharp
return JsonNetResult.InternalError("Computer says no...");
```

returns:

```json
{
    "meta": {
        "code": 500,
        "error": "Computer says no..."
    }
}
```
