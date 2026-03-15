using UnityEngine;

public class ItemEffectManager : MonoBehaviour
{
    [SerializeField] private Door door;
    [SerializeField] private PlayerStats player;  // script simple del player
    [SerializeField] private AudioSource sfx;
    [SerializeField] private AudioClip pickupSound;

    private void OnEnable()
    {
        Pickup.OnItemPicked += ApplyEffect;
    }

    private void OnDisable()
    {
        Pickup.OnItemPicked -= ApplyEffect;
    }

    private void ApplyEffect(ItemData item)
    {
        switch (item.type)
        {
            case ItemType.KeyCard:
                if (door != null)
                {
                    door.OpenDoor();
                }
                break;

            case ItemType.Battery:
                player.ModifySpeed(2f, 10f); // +velocidad 10s
                break;

            case ItemType.AncientRelic:
                player.ModifySpeed(0.5f, 8f); // lento 8s
                break;

            case ItemType.AccessChip:
                player.UnlockDoubleJump();
                break;

            case ItemType.MagicStone:
                sfx.PlayOneShot(pickupSound);
                break;
        }
    }
}