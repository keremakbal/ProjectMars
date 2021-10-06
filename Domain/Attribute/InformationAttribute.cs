using System;
namespace Domain
{
    [AttributeUsage(AttributeTargets.Field)]
    public class InformationAttribute : Attribute
    {
        public string Value { get; set; }
        public string Description { get; set; }
        public string Axis { get; set; }
    }
}
