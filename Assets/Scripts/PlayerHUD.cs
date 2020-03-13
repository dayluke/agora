using UnityEngine;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField] private GameObject canvasGO = null;
    [SerializeField] private GameObject inventoryGO = null;
    [SerializeField] private KeyCode openInventoryKey = KeyCode.I;

    public static Storage inventory;
    public static Storage hotbar;

    private void Awake()
    {
        inventory = inventoryGO.GetComponent<Storage>();
        hotbar = canvasGO.GetComponentInChildren<Storage>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(openInventoryKey))
        {
            bool isInventoryOpen = !inventoryGO.activeSelf;
            inventoryGO.SetActive(isInventoryOpen);
            PlayerMovement.inputEnabled = !isInventoryOpen;
            CursorHandler.ToggleCursor(isInventoryOpen);
        }
    }
}