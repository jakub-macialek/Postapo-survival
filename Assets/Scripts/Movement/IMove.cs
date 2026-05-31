using UnityEngine;

interface IMove
{
    void Move(Vector3 direction, Rigidbody rb, Transform transform);
}
