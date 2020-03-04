using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Create New Item")]
public class Item : ScriptableObject
{
    [SerializeField] private Sprite sprite = null;
    [SerializeField] private ItemType itemType = ItemType.WEAPON;

    public Sprite GetSprite() { return sprite; }
}

public enum ItemType
{
    WEAPON,
    TOOL
}
