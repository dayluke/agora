using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class InteractableObject : MonoBehaviour
{
    [SerializeField] private float range = 5f;
    [SerializeField] private KeyCode interactionKey = KeyCode.E;
    [SerializeField] private Item item = null;

    private void Start()
    {
        GetComponent<SphereCollider>().radius = range; 
    }

    private void OnTriggerStay(Collider coll)
    {
        if (coll.tag == "Player")
        {
            if (Input.GetKeyDown(interactionKey))
            {
                PickUpObject(coll.gameObject);
            }
        }
    }

    private void PickUpObject(GameObject player)
    {
        // try inventory -> hotbar -> return
        Transform slotTransform = PlayerHUD.inventory.GetFirstFreeSlot() != null ? PlayerHUD.inventory.GetFirstFreeSlot() : PlayerHUD.hotbar.GetFirstFreeSlot();

        if (slotTransform == null)
        {
            Debug.LogFormat("Player could not pick up the <color=cyan>{0}</color>.", gameObject.name);
            return;
        }

        slotTransform.GetComponent<Slot>().AssignItem(this.item);
        Debug.LogFormat("Player has picked up an <color=cyan>{0}</color>.", gameObject.name);
        Destroy(this.gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range * transform.localScale.x);
    }
}
