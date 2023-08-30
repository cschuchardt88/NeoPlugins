
namespace Neo.Plugins.Example
{
    public class RestServerPlugin : Plugin
    {
        public override string Name => "RestServerPlugin";
        public override string Description => "This is example description.";

        internal static NeoSystem NeoSystem { get; private set; }

        public RestServerPlugin()
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
