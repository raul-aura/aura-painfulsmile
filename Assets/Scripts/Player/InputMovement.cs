using UnityEngine;

public class InputMovement : MonoBehaviour
{
    private ShipData thisShip;
    public ShipMovement movementClass;

    void Start()
    {
        thisShip = GetComponent<ShipData>();
    }

    protected void Update()
    {
        if (movementClass != null && !thisShip.isDead)
        {
            float inputRotation = Input.GetAxis("Horizontal");
            float inputMovement = Input.GetAxis("Vertical");
            movementClass.Move(inputMovement, transform.up);
            movementClass.Rotate(inputRotation, Vector3.forward);
        }
    }
}
