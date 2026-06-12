using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Transform))]
public class PlayerController : MonoBehaviour
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
    Camera playerCamera;
    [SerializeField]
    PlayerUI playerUI;
    [SerializeField]
    private Logger logger;

    [Header("Input Actions")]
    [SerializeField]
    private InputActionReference moveAction;
    [SerializeField]
    private InputActionReference jumpAction;
    [SerializeField]
    private InputActionReference interactionAction;

    private void OnEnable()
    {
        moveAction.action.Enable();
        jumpAction.action.Enable();
        interactionAction.action.Enable();
    }

    private void OnDisable()
    {
        moveAction.action.Disable();
        jumpAction.action.Disable();
        interactionAction.action.Disable();
    }

    void Awake()
    {
        characterController = GetComponent<CharacterController>();

        if (logger == null)
        {
            Debug.LogError("MouseController didn't found a component that implements ILogger.");
        }
    }

    private void Update()
    {
        HandleMovement();
        HandleInteraction();
    }

    void HandleInteraction()
    {
        Ray ray = playerCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (Physics.Raycast(ray, out RaycastHit hit, 2f))
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            if (interactable != null)
            {
                playerUI.ShowCenteredText("Press E to interact with " + interactable.GetName());
                if (interactionAction.action.WasPressedThisFrame())
                {
                    interactable.OnInteraction(gameObject);
                }
            }
            
        }
        else
        {
            playerUI.HideCenteredText();
        }
    }

    void HandleMovement()
    {
        groundedPlayer = characterController.isGrounded;

        Vector2 input = moveAction.action.ReadValue<Vector2>();

        Vector3 move = (input.x * transform.right) + (transform.forward * input.y);
        move = Vector3.ClampMagnitude(move, 1f);

        if (groundedPlayer && jumpAction.action.WasPerformedThisFrame())
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;

        Vector3 finalMove = (move * playerSpeed) + (Vector3.up * playerVelocity.y);
        characterController.Move(finalMove * Time.deltaTime);
    }
}
