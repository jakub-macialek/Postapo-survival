using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField]
    PlayerUI playerUI;
    [SerializeField]
    Logger logger;

    private InventorySlot[] items = new InventorySlot[2];

    public bool AddItem(ItemScriptableObject item, ushort quantity)
    {
        for (ushort i = 0; i < items.Length; i++)
        {
            if (!items[i].IsEmpty() && items[i].Item == item)
            {
                items[i].AddQuantity(quantity);
                playerUI.UpdateSlots(items);
                logger.Log($"Added {quantity} of {item.name} to existing stack in inventory.");
                return true;
            }
            else if (items[i].IsEmpty())
            {
                items[i] = new InventorySlot(item, quantity);
                playerUI.UpdateSlots(items);
                logger.Log($"Added {item.name} to inventory.");
                return true;
            }
        }
        logger.LogWarning($"Could not add {item.name} to inventory. Inventory is full.");
        return false;
    }

    public void RemoveItem(int index)
    {
        logger.Log($"Attempting to remove item at index {index} from inventory.");
        if (index < 0 || index >= items.Length) { return; }

        logger.Log($"Index {index} is valid. Checking item slot.");
        InventorySlot itemSlot = items[index];
        if (itemSlot.IsEmpty()) { return; }

        logger.Log($"Item slot at index {index} is not empty. Removing item.");
        if (itemSlot.Quantity <= 0) { return; }

        logger.Log($"Item slot at index {index} has quantity {itemSlot.Quantity}. Removing one item.");

        itemSlot.Clear();
        playerUI.UpdateSlots(items);
    }
}