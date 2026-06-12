using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private string[] items = new string[10];

    public void AddItem(string item)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == null)
            {
                items[i] = item;
                Debug.Log($"Added {item} to inventory.");
                return;
            }
        }
        Debug.LogWarning("Inventory is full. Cannot add " + item);
    }
}
