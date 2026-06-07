using UnityEngine;
using System.Collections.Generic;

public class InventoryUI : MonoBehaviour
{
    public static InventoryUI Instance;

    [SerializeField] private GameObject itemSlotPrefab;
    [SerializeField] private GameObject activeItemPrefab;
    private GameObject activeItem;
    [SerializeField] private Transform content;
    [SerializeField] private Transform inGameMenu;
    [SerializeField] private GameObject inventoryPanel;

    public InventorySlot activeSlot { get; private set; }

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        inventoryPanel.SetActive(false);
        RefreshInventory();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            ToggleInventory();
    }

    public void ToggleInventory()
    {
        bool isOpen = !inventoryPanel.activeSelf;
        inventoryPanel.SetActive(isOpen);
        if (activeItem != null)
            activeItem.SetActive(!isOpen);
    }

    public void RefreshInventory()
    {
        foreach (Transform child in content)
            Destroy(child.gameObject);

        foreach (InventorySlot slot in InventoryManager.Instance.slots)
        {
            GameObject go = Instantiate(itemSlotPrefab, content);
            go.GetComponent<ItemSlotUI>().Setup(slot, this);
        }
    }

    public void RefreshActiveItem()
    {
        if (activeItem != null && activeSlot != null)
            activeItem.GetComponent<ItemSlotUI>().Setup(activeSlot, this);
    }

    public void SetActiveItem(InventorySlot activeItem)
    {
        if (activeItem != null && activeItem.GetAmount() > 0)
        {
            if (this.activeItem != null)
                Destroy(this.activeItem);

            activeSlot = activeItem;
            this.activeItem = Instantiate(activeItemPrefab, inGameMenu);
            this.activeItem.GetComponent<ItemSlotUI>().Setup(activeItem, this);
            ToggleInventory();
        }
    }

    public void AddHarvest(Flower flower)
    {
        InventoryManager.Instance.AddHarvest(flower);
        RefreshInventory();
    }
}