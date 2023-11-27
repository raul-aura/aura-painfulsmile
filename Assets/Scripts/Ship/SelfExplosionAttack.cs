using UnityEngine;

public class SelfExplosionAttack : ShipAttack
{
    ShipData thisShip;
    [SerializeField] private GameObject explosionObjectPrefab;

    void Start()
    {
        thisShip = GetComponent<ShipData>();
    }

    public override void Attack()
    {
        if(GameInstance.Instance.GameModeProperty == GameModes.PLAY)
        {
            SpawnExplosion();
            thisShip.selfKill = true;
            thisShip.HealthProperty = 0;
        }
    }

    void SpawnExplosion()
    {
        GameObject explosion = Instantiate(explosionObjectPrefab, transform);
        ExplosionBehaviour explosionClass = explosion.GetComponent<ExplosionBehaviour>();
        explosionClass.damage = attackDamage;
        explosionClass.damageClass = damageClass;
    }
}
