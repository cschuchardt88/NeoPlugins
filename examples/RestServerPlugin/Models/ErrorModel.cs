namespace Neo.Plugins.Example.Models
{
    internal class ErrorModel
    {
        public int Code { get; init; } = 1000;
        public string Name { get; init; } = "GeneralException";
        public string Message { get; init; } = "An error occurred.";
    }
}
