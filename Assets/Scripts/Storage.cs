using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(VerticalLayoutGroup))]
public class Storage : MonoBehaviour
{
    [SerializeField] protected int storageSize = 0;
    [SerializeField] private GameObject slotPrefab = null;
    [SerializeField] protected Slot[] slots;
    [SerializeField] private int rowCount = 0;
    [SerializeField] private int colCount = 0;
    [SerializeField] private float cellSize = 100f;
    [SerializeField] private int cellPadding = 50;
    public StorageType storageType = StorageType.CHEST;

    private void Start()
    {
        slots = new Slot[storageSize];

        if (rowCount > 1)
        {
            int spacing = CalculateSpacing(GetComponent<RectTransform>().rect.height, rowCount, cellSize, cellPadding);
            GetComponent<VerticalLayoutGroup>().spacing = spacing;
            GetComponent<VerticalLayoutGroup>().padding = new RectOffset(0, 0, cellPadding, cellPadding);
        }

        for (int i = 0; i < rowCount; i++)
        {
            GameObject rowGO = new GameObject("Row");
            rowGO.transform.SetParent(gameObject.transform);
            SetupColumn(rowGO.AddComponent<HorizontalLayoutGroup>());
            rowGO.transform.localScale = Vector3.one;

            for (int j = 0; j < colCount; j++)
            {
                Instantiate(slotPrefab, rowGO.transform);
            }
        }
    }

    private void SetupColumn(HorizontalLayoutGroup hlg)
    {
        hlg.childAlignment = TextAnchor.MiddleCenter;
        hlg.childControlWidth = true;
        hlg.childControlHeight = true;
        int spacing = CalculateSpacing(GetComponent<RectTransform>().rect.width, colCount, cellSize, cellPadding);
        hlg.spacing = spacing;
        hlg.padding = new RectOffset (cellPadding, cellPadding, 0, 0);
    }

    private int CalculateSpacing(float size, int cellCount, float cellSize, int cellPadding)
    {
        return (int)Mathf.Floor(size - (cellCount * cellSize) - (cellPadding * 2)) / (cellCount - 1);
    }

    public Transform GetFirstFreeSlot()
    {
        for (int i = 0; i < rowCount; i++)
        {
            for (int j = 0; j < colCount; j++)
            {
                if (transform.GetChild(i).GetChild(j).GetComponent<Slot>().IsSlotEmpty())
                {
                    return transform.GetChild(i).GetChild(j);
                }
            }
        }

        return null;
    }
}

public enum StorageType
{
    INVENTORY,
    HOTBAR,
    CHEST
}