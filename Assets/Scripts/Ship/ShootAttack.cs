using UnityEngine;

public class ShootAttack : ShipAttack
{
    [SerializeField] private GameObject canonballObjectPrefab;
    [SerializeField] private Transform frontalLocator;
    [SerializeField] private Transform[] sideLocators;
    [SerializeField] private float attackCooldown = 0.8f;
    private bool isOnCooldown = false;
    private float timeElapsed = 0f;

    void Update()
    {
        if (isOnCooldown)
        {
            timeElapsed += Time.deltaTime;
            if(timeElapsed >= attackCooldown)
            {
                isOnCooldown = false;
                timeElapsed = 0f;
            }
        }
    }

    public override void Attack()
    {
        AttackFrontal();
    }

    public void AttackFrontal()
    {
        if (!isOnCooldown && GameInstance.Instance.GameModeProperty == GameModes.PLAY)
        {
            SpawnCanonball(frontalLocator, AttackDirections.FRONTAL);
            isOnCooldown = true;
        }
    }

    public void AttackSides()
    {
        if (!isOnCooldown && GameInstance.Instance.GameModeProperty == GameModes.PLAY)
        {
            foreach (Transform locator in sideLocators)
            {
                SpawnCanonball(locator, AttackDirections.SIDE);
            }
            isOnCooldown = true;
        }
    }

    void SpawnCanonball(Transform locator, AttackDirections direction)
    {
        GameObject canonball = Instantiate(canonballObjectPrefab, locator.position, transform.rotation);
        CanonballBehaviour canonballClass = canonball.GetComponent<CanonballBehaviour>();
        canonballClass.canonballDirection = direction;
        canonballClass.damage = attackDamage;
        canonballClass.damageClass = damageClass;
    }
}
