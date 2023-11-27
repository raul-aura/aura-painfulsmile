using UnityEngine;

public class ExplosionBehaviour : MonoBehaviour
{
    [HideInInspector] public int damage;
    [HideInInspector] public ShipDamage damageClass;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(damageClass.DealDamage(collision, damage))
        {
            Destroy(gameObject);
        }       
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, 2f);
    }
}
