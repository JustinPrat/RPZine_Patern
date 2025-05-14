using UnityEngine;

public interface ILooker: ILookReader, ILookWriter {}
public interface ILookReader
{
    public Vector2 LookDirection {get;}
}

public interface ILookWriter
{
    public Vector2 LookDirection {get; set; }
}