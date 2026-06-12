using System;

public struct InventorySlot
{
    public ItemScriptableObject Item { get; private set; }
    public int Quantity { get; private set; }
    public InventorySlot(ItemScriptableObject item, int quantity)
    {
        Item = item;
        Quantity = quantity;
    }
    public void AddQuantity(int amount = 1)
    {
        Quantity += amount;
    }
    public void RemoveQuantity(int amount = 1)
    {
        Quantity -= amount;
        Quantity = Math.Clamp(Quantity, 0, ushort.MaxValue);
    }

    public bool IsEmpty()
    {
        return Item == null || Quantity <= 0;
    }

    public void Clear()
    {
        Item = null;
        Quantity = 0;
    }
}