using UnityEngine;

public class ShipDamage : MonoBehaviour
{
    ShipData thisShip;

    void Start()
    {
        thisShip = GetComponent<ShipData>();
    }

    public bool DealDamage(Collider2D collision, int damage)
    {
        ShipData ship = collision.gameObject.GetComponentInParent<ShipData>();
        if (ship != null && ship.shipType != thisShip.shipType && !ship.isDead)
        {
            ship.Damage(damage);
            return true;
        }
        return false;
    }
}
