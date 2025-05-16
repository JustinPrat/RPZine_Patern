using System;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField] private HealthComponent _player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(typeof(IHealth), out Component health))
        {
            IHealth player = (IHealth)health;
            if (player == _player)
            {
                player.Death();
            }
        }
    }

}
