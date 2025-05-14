using UnityEngine;

public interface ISpeeder: ISpeedReader, ISpeedWriter {}

public interface ISpeedReader
{
    public Vector2 Speed { get; }
}

public interface ISpeedWriter
{
    public Vector2 Speed { get; set; }
}