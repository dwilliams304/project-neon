using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;


    [Header("References")]
    [SerializeField] private GameObject player;
    private PlayerStats playerStats;


    [Header("Difficulty Settings")]
    [SerializeField] private AnimationCurve enemyHealthScaler;
    [SerializeField] private AnimationCurve enemyDamageScaler;

    [Header("Other Variables")]
    [SerializeField] private float damageVariance;




    void Awake() => Instance = this;

    void Start(){
        playerStats = player.GetComponent<PlayerStats>();
    }

    public bool CalculateIfCrit(){
        if(Random.Range(0, 101) <= playerStats.CritChance.Value) return true;
        return false;
    }

    public int CalculatePlayerDamageDone(bool wasCrit){
        float finalDamage;
        float variance = Random.Range(-damageVariance, damageVariance);
        finalDamage = playerStats.BaseDamage.Value + variance;
        if(wasCrit){
            finalDamage *= playerStats.CritDamageMultiplier.Value;
        }
        return Mathf.CeilToInt(finalDamage);
    }

    public float CalculateDamage(Stat damageStat){
        float variance = Random.Range(-damageVariance, damageVariance);
        if(damageStat == null) return 10 + variance;
        return damageStat.Value + variance;
    }

}
