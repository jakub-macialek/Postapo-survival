using UnityEngine;

public class PlayerMove : MonoBehaviour, IMove
{
    [SerializeField] private float speed = 12f;
    [SerializeField] private ForceMode stopForceMode = ForceMode.Force;
    [SerializeField] private float stopPower = 2.4f;

    public void Move(Vector3 direction, Rigidbody rb)
    {
        rb.AddForce(direction * speed);
    }
}
