using UnityEngine;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour
{
    private List<ItemData> collectedItems = new List<ItemData>();

    private void OnEnable()
    {
        Pickup.OnItemPicked += AddItem;
    }

    private void OnDisable()
    {
        Pickup.OnItemPicked -= AddItem;
    }

    private void AddItem(ItemData item)
    {
        collectedItems.Add(item);
        Debug.Log("Picked: " + item.itemName);
    }
}
