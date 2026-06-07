using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Flower")]
public class Flower : ScriptableObject
{
    public string flowerName;
    public Sprite[] growthStages;
    public Sprite harvestIcon;
    public Sprite seedIcon;
}