using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField] 
    private float sensitivity = 100f;

    [Header("References")]
    [SerializeField]
    Logger logger;
    [SerializeField]
    private Transform playerCamera;

    [Header("Input Actions")]
    [SerializeField]
    InputActionReference lookAction;

    private float xRotation = 0f;

    private void OnEnable()
    {
        if (lookAction != null) lookAction.action.Enable();
    }

    private void OnDisable()
    {
        if (lookAction != null) lookAction.action.Disable();
    }

    private void Start()
    {
        if (lookAction == null)
        {
            logger.LogError("Look action is missing in the Input System actions.");
        }
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (lookAction == null) return;

        Vector2 input = lookAction.action.ReadValue<Vector2>();

        float mouseX = input.x * sensitivity;
        float mouseY = input.y * sensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
}
