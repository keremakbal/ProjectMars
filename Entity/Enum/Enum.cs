using Domain;

namespace Entity
{
    public enum Command
    {
        [Information(Value = "L")]
        Left,
        [Information(Value = "R")]
        Right,
        [Information(Value = "M")]
        Move
    }

    public enum MissionType
    {
        [Information(Value = "L")]
        Landing,
        [Information(Value = "D")]
        Discover
    }
}
