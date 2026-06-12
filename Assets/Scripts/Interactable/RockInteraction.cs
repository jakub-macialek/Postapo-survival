using UnityEngine;

public class RockInteraction : Interactable
{
    [SerializeField]
    private ItemScriptableObject item;
    [SerializeField]
    private GameObject objectToDestroy;
    [SerializeField]
    private ushort quantity = 1;

    public override void OnInteraction(GameObject player)
    {
        base.OnInteraction(player);
        try
        {
            if (player.TryGetComponent(out PlayerInventory inventory))
            {
                Debug.Log($"Player interacted with {gameObject.name} and is adding {item.itemName} to inventory.");
                if ( inventory.AddItem(item, quantity) )
                {
                    Debug.Log($"{item.itemName} added to inventory. Destroying {gameObject.name}.");
                    Destroy(gameObject);
                }
            }
            else
            {
                Debug.LogError("Player doesn't have a PlayerInventory component.");
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"An error occurred while interacting with the stone: {ex.Message}");
        }
    }
}
