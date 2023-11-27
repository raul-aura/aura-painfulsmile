using UnityEngine;

public class EnemyMovement : ShipMovement
{
    [HideInInspector] public bool isFacingPlayer;

    public float angleTolerance = 5f;

    public override void Rotate(float rotationAxis, Vector3 rotationDirection)
    {
        Quaternion newRotation = Quaternion.AngleAxis(rotationAxis - 90f, rotationDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * speedRotation);

        float angleDifference = Quaternion.Angle(transform.rotation, newRotation);
        if(angleDifference <= angleTolerance)
        {
            isFacingPlayer = true;
        }
        else
        {
            isFacingPlayer = false;
        }
    }
}
