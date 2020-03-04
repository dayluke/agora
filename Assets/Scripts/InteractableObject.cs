using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class InteractableObject : MonoBehaviour
{
    [SerializeField] private float range = 5f;
    [SerializeField] private KeyCode interactionKey = KeyCode.E;

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
                PickUpObject();
            }
        }
    }

    private void PickUpObject()
    {
        Debug.LogFormat("Player has picked up an <color=cyan>{0}</color>", gameObject.name);
    }
}
