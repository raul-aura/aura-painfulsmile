using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] protected float speedRotation = 100f;
    [SerializeField] protected float speedMovement = 3.5f;
    protected Rigidbody2D shipRigidbody;

    protected void Start()
    {
        shipRigidbody = GetComponent<Rigidbody2D>();
    }
    
    public virtual void Move(float movementAxis, Vector2 movementDirection)
    {
        if (movementAxis > 0 && GameInstance.Instance.GameModeProperty == GameModes.PLAY)
        {
            shipRigidbody.velocity = movementDirection * movementAxis * speedMovement;
        }
        else
        {
            StopMovement();
        }
    }

    public virtual void Rotate(float rotationAxis, Vector3 rotationDirection)
    {
        if(rotationAxis != 0 && GameInstance.Instance.GameModeProperty == GameModes.PLAY)
        {
            float rotationAmount = -rotationAxis * speedRotation * Time.deltaTime;
            transform.Rotate(rotationDirection * rotationAmount);
        }
    }

    public void StopMovement()
    {
        shipRigidbody.velocity = Vector2.zero;
    }
}
