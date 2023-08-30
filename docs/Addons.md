## RestServer Plugin
In this secion of you will learn how to make a Neo cli plugin that integrates with `RestServer` Plugin.
Lets take a look at [Example Plugin](/examples/RestServerPlugin).


## Folder Structure
The only thing that is important here is the `controllers` folder. This folder is required for the `RestServer`
plugin to register the controllers in its web server. This location is where you put all your controllers.

```bash
Project
├── Controllers
│   └── ExampleController.cs
├── ExamplePlugin.cs
├── ExamplePlugin.csproj
├── Exceptions
│   └── CustomException.cs
└── Models
    └── ErrorModel.cs
```

## Controllers
The `controller` class is the same as ASP.Net Core controllers. Controllers must have their attribute set
as `[ApiController]` and inherent from the `ControllerBase`.

## Swagger Controller
A `Swagger` controller uses special attributes that are set on the your controller class.

**Controller Class Attributes**
- `[Produces(MediaTypeNames.Application.Json)]` (_Required_)
- `[Consumes(MediaTypeNames.Application.Json)]` (_Required_)
- `[ApiExplorerSettings(GroupName = "v1")]`
  - **GroupName** - _is which version of the API you are targeting._
- `[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorModel))]` (_Required_)
  - **Type** - _is must have a base of [error](#error-model) model class._

## Error Model
Error model class is must and needs to the same as `RestServer`'s of else there will be some inconsistencies
with end users not knowing which type to use. This model class can be `public` or `internal`. Error codes
can be whatever you desire. Same goes for the `Name` property and obviously `Message` property.

**Model**
```csharp
internal class ErrorModel
{
    public int Code { get; init; };
    public string Name { get; init; };
    public string Message { get; init; };
}
```

## Controller Actions
Controller actions need to have special attributes as well as code comments.

**Required Attributes**

You can have more than one of this attribute. Depending upon what your action is doing.
- `[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]`
  - **Type** - _is whichever type your action will be returning._
  - **Status Code** - _is status code` you will be return as well._

**Action Example**
```charp
[HttpGet("contracts/{hash:required}/sayHello", Name = "GetSayHello")]
[ProducesResponseType(StatusCodes.Status204NoContent)]
[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
public IActionResult GetSayHello(
    [FromRoute(Name = "hash")]
    UInt160 scripthash)
{
    if (scripthash == UInt160.Zero)
        return NoContent();
    return Ok($"Hello, {scripthash}");
}
```
Notice that the _above_ example also returns with a HTTP status code of `204 No Content`.
This action `route` also extends the `contracts` API. Adding method `sayHello` to it. Routes
can be what you like as well. But if you want to extend on any existing controller you must use
routes

**Existing Routes**
- `/api/v1/contracts/`
- `/api/v1/ledger/`
- `/api/v1/node/`
- `/api/v1/tokens`
- `/api/v1/Utils/`

**Excluded Routes**
- `/api/v1/wallet/`

_for security reasons_.

**Code Comments for Swagger**
```csharp
/// <summary>
/// 
/// </summary>
/// <param name="" example=""></param>
/// <returns></returns>
/// <response code="200">Successful</response>
/// <response code="400">An error occurred. See Response for details.</response>
```
_Above_ you see the example of the comments. You just fill in the blanks. Summary is the
description that gets used for `Swagger`. A long with `parma` and `returns`. Also note that
you need to have `GenerateDocumentationFile` enabled and added to your `.csproj` file. The
`xml` file that is generated. In our case would be `RestServerPlugin.xml`. This file gets put
the same folder `Plugins/RestServerPlugin/` in the root of the `neo-node` executable folder.
Where you will see `neo-cli.exe`. File `RestServerPlugin.xml` will get added to `Swagger`
automatically by the `RestServer` plugin.
