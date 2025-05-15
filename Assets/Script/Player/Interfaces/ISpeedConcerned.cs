using System;
using UnityEngine;

public interface ISpeedConcerned: ISpeedReader, ISpeedWriter {}

public interface ISpeedReader
{
    public float Speed { get; }
    public event Action<float> OnSpeedUpdated;
}

public interface ISpeedWriter
{
    public float Speed { get; set; }
}