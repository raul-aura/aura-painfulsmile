using UnityEngine;

public class InputAttack : MonoBehaviour
{
    private ShipData thisShip;
    public ShootAttack attackClass;

    void Start()
    {
        thisShip = GetComponent<ShipData>();
    }

    void Update()
    {
        if(attackClass != null && !thisShip.isDead)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                attackClass.AttackFrontal();
            }
            if (Input.GetMouseButtonDown(1))
            {
                attackClass.AttackSides();
            }
        }
    }
}
