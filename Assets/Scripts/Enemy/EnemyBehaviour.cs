using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private ShipData thisShip;
    [HideInInspector] public ShipData playerShip;
    public EnemyMovement movementClass;
    public ShipAttack attackClass;
    [SerializeField] private float detectionRadius = 5f;
    [SerializeField] private float attackRadius = 4f;

    void Start()
    {   
        thisShip = GetComponent<ShipData>();
    }

    void Update()
    {
        if(playerShip != null && !playerShip.isDead && movementClass != null && !thisShip.isDead)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, playerShip.transform.position);
            Vector3 playerDirection = playerShip.transform.position - transform.position;
            if(distanceToPlayer < detectionRadius)
            {   
                float angle = Mathf.Atan2(playerDirection.y, playerDirection.x) * Mathf.Rad2Deg;
                movementClass.Rotate(angle, Vector3.forward);
                if(distanceToPlayer < attackRadius && attackClass != null)
                {
                    movementClass.StopMovement();
                    if(movementClass.isFacingPlayer)
                    {
                        attackClass.Attack();
                    }
                }
                else
                {
                    movementClass.Move(1f, transform.up);
                }
            }
            else
            {
                movementClass.StopMovement();
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
