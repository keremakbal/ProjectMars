namespace Entity
{
    public interface IOrientation
    {
        string Key { get; }
        string Name { get; }
        int AxisX { get; }
        int AxisY { get; }
        int Angle { get; }
    }
}
