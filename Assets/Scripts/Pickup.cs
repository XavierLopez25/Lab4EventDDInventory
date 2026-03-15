using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] private ItemData itemData;

    public delegate void OnPickup(ItemData item);
    public static event OnPickup OnItemPicked;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Pick();
        }
    }

    public void Pick()
    {
        OnItemPicked?.Invoke(itemData);
        Destroy(gameObject);
    }
}