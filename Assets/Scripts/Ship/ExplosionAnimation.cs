using UnityEngine;

public class ExplosionAnimation : MonoBehaviour
{
    private Animator explosionAnimator;
    public ExplosionTypes explosionType;
    private string animationName = "A_Explosion";

    void Start()
    {
        explosionAnimator = GetComponent<Animator>();
        Activate();
    }

    public void Activate()
    {
        switch(explosionType)
        {
            case ExplosionTypes.DAMAGE:
                animationName += "_Damage";
                break;
            case ExplosionTypes.DEATH:
                animationName += "_Death";
                break;
        }
        explosionAnimator.Play(animationName);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}

public enum ExplosionTypes
{
    DAMAGE,
    DEATH
}