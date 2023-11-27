using UnityEngine;

public class CanonballBehaviour : MonoBehaviour
{
    [SerializeField] private float speedMovement =  5f;
    [SerializeField] private GameObject damageAnimationPrefab;
    [HideInInspector] public int damage;
    [HideInInspector] public AttackDirections canonballDirection;
    [HideInInspector] public ShipDamage damageClass;
    Vector3 direction;
    Rigidbody2D canonballRigidbody;

    void Start()
    {
        canonballRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        switch(canonballDirection)
        {
            case AttackDirections.FRONTAL:
                direction = transform.up;
                break;
            case AttackDirections.SIDE:
                direction = transform.right;
                break;
        }
        canonballRigidbody.velocity = direction * speedMovement;
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(damageClass.DealDamage(collision, damage))
        {
            Instantiate(damageAnimationPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        else if(collision.CompareTag("Bounds"))
        {
            Destroy(gameObject);
        }
    }
}

public enum AttackDirections 
{
    FRONTAL,
    SIDE
}
