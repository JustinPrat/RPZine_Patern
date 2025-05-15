using UnityEngine;

public interface IInputDirectionConcerned : IInputDirectionReader, IInputDirectionWriter
{
           
}

public interface IInputDirectionReader
{
    public Vector2 InputDirection { get; } 
}

public interface IInputDirectionWriter
{
    public Vector2 InputDirection { get; set; } 
}