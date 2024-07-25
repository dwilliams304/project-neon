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

    private void OnEnable(){
        healthSystem = GetComponent<Health>();
        healthSystem.onUnitDeath += EnemyDeath;
    }

    private void OnDisable(){
        healthSystem.onUnitDeath -= EnemyDeath;
    }

    void Start(){
        healthSystem = GetComponent<Health>();
    }

    public void OnDamage()
    {
        healthSystem.TakeDamage(10);
    }


    private void EnemyDeath(){
        XPManager.Instance.AddExperience(10);
        gameObject.SetActive(false);
    }
}
