using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Transform))]
public class PlayerMovementController : MonoBehaviour
{
    [SerializeField]
    private float playerSpeed = 5f;
    [SerializeField]
    private float jumpHeight = 2f;
    private float gravityValue = -9.81f;

    private CharacterController characterController;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    [SerializeField]
    private ILogger logger;

    [Header("Input Actions")]
    [SerializeField]
    private InputActionReference moveAction;
    [SerializeField]
    private InputActionReference jumpAction;

    private void OnEnable()
    {
        moveAction.action.Enable();
        jumpAction.action.Enable();
    }

    private void OnDisable()
    {
        moveAction.action.Disable();
        jumpAction.action.Disable();
    }

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        logger = GetComponent<ILogger>();

        if (logger == null)
        {
            Debug.LogError("MouseController didn't found a component that implements ILogger.");
        }
    }

    private void Update()
    {
        groundedPlayer = characterController.isGrounded;

        if ( groundedPlayer )
        {
            if ( !moveAction.action.enabled )
            {
                moveAction.action.Enable();
            }
            
        }
        else
        {
            moveAction.action.Disable();
        }

        Vector2 input = moveAction.action.ReadValue<Vector2>();

        Vector3 move = ( input.x * transform.right ) + ( transform.forward * input.y );
        move = Vector3.ClampMagnitude(move, 1f);
        
        if( groundedPlayer && jumpAction.action.WasPerformedThisFrame() )
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;

        Vector3 finalMove = ( move * playerSpeed ) + ( Vector3.up * playerVelocity.y );
        characterController.Move(finalMove * Time.deltaTime);
    }
}
