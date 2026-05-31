using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Transform))]
public class PlayerMoveDirectionReader : MonoBehaviour, IReadPlayerMoveDirection
{
    [SerializeField]
    InputActionReference moveAction;

    private void OnEnable()
    {
        if(moveAction != null) moveAction.action.Enable();
    }
    private void OnDisable()
    {
        if(moveAction != null) moveAction.action.Disable();
    }

    void Start()
    {
        if ( moveAction == null)
        {
            Debug.LogError("No Move action found");
        }
    }

    public Vector3 GetMoveDirection()
    {
        if (moveAction == null) return Vector3.zero;

        Vector2 input = moveAction.action.ReadValue<Vector2>();
        
        if(input.sqrMagnitude > 1f)
        {
            input.Normalize();
        }

        return new Vector3(input.x, 0f, input.y);
    }
}
