namespace Neo.Plugins.Models
{
    internal class EmptyErrorModel
    {
        public int Code { get; init; } = 1000;
        public string Name { get; init; } = "GeneralException";
        public string Message { get; init; } = "An error occurred.";
    }
}
