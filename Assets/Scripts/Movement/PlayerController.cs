using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody playerRigidbody;
    IMove movement;
    IGetMoveDirection direction;
    ILogger logger;

    void Awake()
    {
        movement = GetComponent<IMove>();
        direction = GetComponent<IGetMoveDirection>();
        logger = GetComponent<ILogger>();
    }

    private void Start()
    {
        if (logger == null)
        {
            Debug.LogError("ILogger component is missing on " + gameObject.name);
        }
        if (playerRigidbody == null)
        {
            logger.LogError("Rigidbody component is missing on " + gameObject.name);
        }
        if (movement == null)
        {
            logger.LogError("IMove component is missing on " + gameObject.name);
        }
        if (direction == null)
        {
            logger.LogError("IGetMoveDirection component is missing on " + gameObject.name);
        }
    }

    private void FixedUpdate()
    {
        movement.Move(direction.GetMoveDirection(), playerRigidbody);
    }
}
