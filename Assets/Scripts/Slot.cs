using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Item item;

    private void Start()
    {
        if (item != null) AssignItem(item);
    }

    public void AssignItem(Item newItem)
    {
        item = newItem;
        Debug.Log(gameObject.name + " WAS ASSIGNED NEW ITEM: " + item.name);
        ChangeSprite();
    }

    public void OnSlotClicked()
    {
        // Move to destination
        Debug.Log("IS SLOT EMPTY: " + IsSlotEmpty());
        
        if (!IsSlotEmpty())
        {
            Storage storage = DetermineWhereToSendItem().GetComponent<Storage>();
            
            TransferItemToNewSlot(storage.GetFirstFreeSlot());

            item = null;
            ChangeSprite();
        }
    }

    private Transform DetermineWhereToSendItem()
    {
        StorageType storage = transform.parent.parent.GetComponent<Storage>().storageType;

        if (storage == StorageType.CHEST)
        {
            // If a chest slot was clicked, then try and send the item to inventory
            return PlayerHUD.inventory.transform;
        }
        else if (storage == StorageType.INVENTORY)
        {
            // If an inventory slot was clicked, then try and send the item to chest
            // return GameObject.Find("Chest").transform;
            return PlayerHUD.hotbar.transform;
        }
        else if (storage == StorageType.HOTBAR)
        {
            // If a hotbar slot was clicked, then try and send the item to inventory
            return PlayerHUD.inventory.transform;
        }
        return null;
    }

    private void TransferItemToNewSlot(Transform parent)
    {
        parent.GetComponent<Slot>().AssignItem(item);
    }

    private void ChangeSprite()
    {
        if (item != null) transform.GetChild(0).GetComponent<Image>().sprite = item.GetSprite();
        else transform.GetChild(0).GetComponent<Image>().sprite = null;
    }

    public bool IsSlotEmpty()
    {
        return item == null;
    }
}
