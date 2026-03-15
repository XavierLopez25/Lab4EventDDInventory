using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject itemSlotPrefab;
    [SerializeField] private Transform contentParent;

    private void OnEnable()
    {
        Pickup.OnItemPicked += AddItemToUI;
    }

    private void OnDisable()
    {
        Pickup.OnItemPicked -= AddItemToUI;
    }

    private void AddItemToUI(ItemData item)
    {
        GameObject slot = Instantiate(itemSlotPrefab, contentParent);

        slot.transform.Find("ItemName").GetComponent<TextMeshProUGUI>().text = item.itemName;
        slot.transform.Find("ItemIcon").GetComponent<Image>().sprite = item.icon;
    }
}