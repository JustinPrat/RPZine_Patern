using UnityEngine;

public interface IBasicMover : IJumper, ILooker, ISpeedConcerned, IInputDirectionConcerned
{
           
}

public interface IVelocityReader
{
    public Vector2 LinearVelocity { get; } 
}