
namespace Neo.Plugins.DummyPlugin
{
    public class DummyPlugin : Plugin
    {
        public override string Name => "DummyPlugin";
        public override string Description => "DummyPlugin";

        internal static NeoSystem NeoSystem { get; private set; }

        public DummyPlugin()
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
