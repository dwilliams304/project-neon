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

    public Stat Damage;

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
        bool _wasCrit = GameManager.Instance.CalculateIfCrit();
        int _damage = GameManager.Instance.CalculatePlayerDamageDone(_wasCrit);
        healthSystem.TakeDamage(_damage, _wasCrit);
    }


    private void EnemyDeath(){
        XPManager.Instance.AddExperience(10);
        gameObject.SetActive(false);
    }
}
