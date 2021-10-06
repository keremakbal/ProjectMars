namespace Facade
{
    internal static class RegexPatterns
    {
        public const string PlateauCoordinate = @"([1-9]\d*)\s([1-9]\d*)$";
        public const string RoverCoordinate = @"([1-9]\d*)\s([1-9]\d*)\s([NSWEnswe]{1})$";
        public const string Command = @"([LRMlrm]{1,})$";
    }
}
