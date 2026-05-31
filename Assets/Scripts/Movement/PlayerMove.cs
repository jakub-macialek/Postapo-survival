using UnityEngine;

public class PlayerMove : MonoBehaviour, IMove
{
    [SerializeField] private float speed = 50f;
    [SerializeField] private ForceMode stopForceMode = ForceMode.Force;
    [SerializeField] private float stopPower = 2.4f;
    [SerializeField] private float maxSpeed = 10f;

    public void Move(Vector3 inputDirection, Rigidbody rb, Transform transform)
    {
        Vector3 direction = (inputDirection.x * transform.right) + (inputDirection.z * transform.forward);
        direction.y = 0f;

        rb.AddForce(direction * speed, ForceMode.Force);

        Vector3 flatVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        if(direction == Vector3.zero)
        {
            rb.AddForce(-flatVelocity * stopPower, stopForceMode);
        }

        if (flatVelocity.sqrMagnitude > (maxSpeed * maxSpeed))
        {
            Vector3 limitedVelocity = flatVelocity.normalized * maxSpeed;

            rb.linearVelocity = new Vector3(limitedVelocity.x, rb.linearVelocity.y, limitedVelocity.z);
        }
    }
}
