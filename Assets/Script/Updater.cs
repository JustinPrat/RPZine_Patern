using System;
using UnityEngine;

public class Updater : MonoBehaviour
{
    public event Action OnUpdate;
    public event Action OnFixedUpdate;

    private void Update()
    {
        OnUpdate?.Invoke();
    }

    private void FixedUpdate()
    {
        OnFixedUpdate?.Invoke();
    }
}