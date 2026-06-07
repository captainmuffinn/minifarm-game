using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemSlotUI : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI amountText;
    [SerializeField] private Button button;

    private InventorySlot slot;
    private InventoryUI inventoryUI;

    public void Setup(InventorySlot slot, InventoryUI inventoryUI)
    {
        this.slot = slot;
        this.inventoryUI = inventoryUI;
        icon.sprite = slot.GetIcon();
        nameText.text = slot.GetName();
        amountText.text = slot.GetAmount().ToString();
        if (button != null)
        {
            button.onClick.AddListener(() => inventoryUI.SetActiveItem(slot));
        }
    }
}
