using UnityEngine;

public abstract class Interactable : MonoBehaviour, IIinteractable
{
    [SerializeField]
    private float distance = 2f;

    public virtual void OnInteraction(GameObject player)
    {
        try
        {
            if (player == null)
            {
                throw new System.ArgumentNullException(nameof(player), "Player GameObject cannot be null.");
            }
            if (Vector3.Distance(player.transform.position, transform.position) > distance)
            {
                Debug.LogWarning("Player is too far away to interact with this object.");
                return;
            }
            Debug.Log("Interacted with " + gameObject.name);
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"An error occurred while interacting with {gameObject.name}: {ex.Message}");
        }
    }

    public virtual string GetName()
    {
        return string.Empty;
    }
}
