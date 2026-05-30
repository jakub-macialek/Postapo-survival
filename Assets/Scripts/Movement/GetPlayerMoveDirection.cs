using UnityEngine;
using UnityEngine.InputSystem;

public class GetPlayerMoveDirection : MonoBehaviour, IGetMoveDirection
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
            Debug.LogError("No Move action finded");
        }
    }

    public Vector3 GetMoveDirection()
    {
        if (moveAction == null) return Vector2.zero;

        Vector2 input = moveAction.action.ReadValue<Vector2>();
        
        if(input.sqrMagnitude > 1f)
        {
            input.Normalize();
        }

        return (input.x * transform.right) + (input.y * transform.forward);
    }
}
