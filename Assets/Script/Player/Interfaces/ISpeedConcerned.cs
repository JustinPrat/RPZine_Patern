using UnityEngine;

public interface ISpeedConcerned: ISpeedReader, ISpeedWriter {}

public interface ISpeedReader
{
    public float Speed { get; }
}

public interface ISpeedWriter
{
    public float Speed { get; set; }
}