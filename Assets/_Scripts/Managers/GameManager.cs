using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;



    [Header("References")]
    [SerializeField] private GameObject player;
    private PlayerCombat playerCombat;
    private PlayerMovement playerMovement;


    [Header("Difficulty Settings")]
    [SerializeField] private AnimationCurve enemyHealthScaler;
    [SerializeField] private AnimationCurve enemyDamageScaler;

    [Header("Other Variables")]
    [SerializeField] private float damageVariance;

    void Awake() => Instance = this;

    void Start(){
        playerCombat = player.GetComponent<PlayerCombat>();
        playerMovement = player.GetComponent<PlayerMovement>();
    }

    public bool CalculateIfCrit(){
        if(Random.Range(0, 101) <= playerCombat.CritChance.Value) return true;
        return false;
    }

    public int CalculatePlayerDamageDone(bool wasCrit){
        float finalDamage;
        float variance = Random.Range(-damageVariance, damageVariance);
        finalDamage = playerCombat.Damage.Value + variance;
        if(wasCrit){
            finalDamage *= playerCombat.CritDamageMultiplier.Value;
        }
        return Mathf.CeilToInt(finalDamage);
    }

    public float CalculateDamage(Stat damageStat = null){
        float variance = Random.Range(-damageVariance, damageVariance);
        if(damageStat == null) return 10 + variance;
        return damageStat.Value + variance;
    }

}
