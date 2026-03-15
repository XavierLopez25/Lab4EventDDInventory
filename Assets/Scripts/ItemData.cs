using UnityEngine;

public enum ItemType
{
    KeyCard,
    Battery,
    AncientRelic,
    AccessChip,
    MagicStone
}

[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Objects/ItemData")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public ItemType type;
}