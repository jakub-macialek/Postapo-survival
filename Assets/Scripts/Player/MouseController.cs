using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Transform))]
public class MouseController : MonoBehaviour
{
    [SerializeField] 
    private float sensitivity = 100f;

    [SerializeField]
    private Transform cameraTransform;
    [SerializeField] 
    private Logger logger;

    [Header("Input Actions")]
    [SerializeField] InputActionReference lookAction;
    [SerializeField] InputActionReference openInventoryAction;

    private float xRotation = 0f;

    private void OnEnable()
    {
        lookAction.action.Enable();
        openInventoryAction.action.Enable();
    }

    private void OnDisable()
    {
        lookAction.action.Disable();
        openInventoryAction.action.Disable();
    }

    private void Awake()
    {
        if (logger == null )
        {
            Debug.LogError("MouseController didn't found a component that implements ILogger.");
        }
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            if (openInventoryAction.action.WasPressedThisFrame())
            {
                Cursor.lockState = CursorLockMode.None;
                logger.Log("Inventory opened. Cursor unlocked.");
                return;
            }

        }
        else
        {
            if (openInventoryAction.action.WasPressedThisFrame())
            {
                Cursor.lockState = CursorLockMode.Locked;
                logger.Log("Inventory closed. Cursor locked.");
                return;
            }
            return;
        }

        Vector2 input = lookAction.action.ReadValue<Vector2>();

        Vector2 mouse = new Vector2(input.x, input.y) * sensitivity * Time.fixedDeltaTime;

        xRotation -= mouse.y;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        transform.Rotate( 0f, mouse.x, 0f );
    }
}
