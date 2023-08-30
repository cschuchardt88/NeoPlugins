### RestServer Plugin
In this secion of you will learn how to make a Neo cli plugin that integrates with `RestServer` Plugin.


### Folder Structure
The structure of the folders is important here.

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



### Neo Plugin Template C#
The code _below_ is most basic `code` you will need to start an `neo-cli` plugin.

**ExamplePlugin.cs**
```csharp
namespace Neo.Plugins.Example
{
    public class ExamplePlugin : Plugin
    {
        public override string Name => "ExamplePlugin";
        public override string Description => "This is an example plugin.";

        internal static NeoSystem NeoSystem { get; private set; }

        public ExamplePlugin()
        {
        }

        protected override void Configure()
        {
            
        }

        protected override void OnSystemLoaded(NeoSystem system)
        {
            NeoSystem = system;
        }
    }
}
```