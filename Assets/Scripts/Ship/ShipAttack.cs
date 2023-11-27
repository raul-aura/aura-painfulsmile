using UnityEngine;

public class ShipAttack : MonoBehaviour
{
    public ShipDamage damageClass;

    [SerializeField] protected int attackDamage = 10;

    public virtual void Attack() {}
}
