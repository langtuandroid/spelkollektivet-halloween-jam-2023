using UnityEngine;

public class PositionInTime
{
    public Vector3 Position { get; set; }
    public Vector3 Velocity { get; set; }
    public Quaternion Quaternion { get; set; }

    public PositionInTime(Vector3 position, Vector3 velocity, Quaternion quaternion)
    {
        Position = position;
        Velocity = velocity;
        Quaternion = quaternion;
    }
}