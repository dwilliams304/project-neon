using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum EnemyState {
    Spawning,
    Idle,
    Chasing,
    Dead
}

public class Enemy : MonoBehaviour, IDamageable
{
    private Health healthSystem;

    void Start(){
        healthSystem = GetComponent<Health>();
    }

    public void OnDamage()
    {
        healthSystem.TakeDamage(10);
    }
}
