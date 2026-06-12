using UnityEngine;

public class StoneInteraction : Interactable
{
    [SerializeField]
    private string _name = "Stone";

    public override void OnInteraction(GameObject player)
    {
        base.OnInteraction(player);
        try
        {
            if (player.TryGetComponent(out PlayerInventory inventory))
            {
                inventory.AddItem("Stone");
                Destroy(gameObject);
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

    public override string GetName()
    {
        return _name;
    }
}
