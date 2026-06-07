using UnityEngine;


[System.Serializable]
public class InventorySlot
{
    public Flower flower;
    public bool isSeed;
    public int amount;

    public int GetAmount()
    {
        return amount;
    }
    public string GetName()
    {
        if (isSeed)
        {
            if (flower.flowerName != "Lavendel")
            {
                return flower.flowerName + "n Samen";
            }
            return flower.flowerName + " Samen";
        }
        return flower.flowerName;
    } 
    public UnityEngine.Sprite GetIcon()
    {
        if (isSeed)
        {
            return flower.seedIcon;
        }
        return flower.harvestIcon;
    }

    public void RemoveOne()
    {
        if (amount > 0) amount--;
    }

    public void AddOne()
    {
        amount++;
    }
}