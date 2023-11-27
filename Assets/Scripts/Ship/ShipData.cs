using UnityEngine;

public class ShipData : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private ShipHealthBar healthBar;
    private int currentHealth;
    public int HealthProperty
    {
        get { return currentHealth; }
        set
        {
            currentHealth = Mathf.Clamp(value, 0, maxHealth);
            UpdateAnimation(value);
            UpdateHealthBar(value);
            if(currentHealth == 0)
            {
                Kill();
            }
        }
    }
    public ShipTypes shipType;
    public GameObject deathAnimationPrefab;
    [HideInInspector] public bool isDead = false;
    [HideInInspector] public bool selfKill = false;
    private Animator shipAnimator;

    void Start()
    {
        shipAnimator = GetComponent<Animator>();
        if(healthBar != null)
        {
            healthBar.thisShip = this;
        }
        HealthProperty = maxHealth;
    }

    public void Damage(int damage)
    {
        HealthProperty -= damage;
    }

    public void Kill()
    {
        isDead = true;
        Instantiate(deathAnimationPrefab, transform);
        if(shipType == ShipTypes.ENEMY && !selfKill)
        {
            PlayerPoints.Instance.AddPoints();
        }
        if(shipType == ShipTypes.PLAYER)
        {
            GameInstance.Instance.EndSession();
        }
    }
    
    public void UpdateAnimation(int health)
    {
        if(shipAnimator != null)
        {
            shipAnimator.SetInteger("shipHealth", health);
        }
    }

    public void UpdateHealthBar(int health)
    {
        if(healthBar != null)
        {
            healthBar.UpdateValue(health, maxHealth);
        }
    }

    public void Reset()
    {
        HealthProperty = maxHealth;
        isDead = false;
        if(shipType == ShipTypes.PLAYER)
        {
            transform.position = Vector3.zero;
            transform.rotation = Quaternion.Euler(Vector3.zero);
            PlayerPoints.Instance.ResetPoints();
        }
    }
}

public enum ShipTypes
{
    PLAYER,
    ENEMY
}