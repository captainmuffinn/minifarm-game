using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public List<InventorySlot> slots = new();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddHarvest(Flower flower)
    {
        InventorySlot existing = slots.Find(s => s.flower == flower && !s.isSeed);
        if (existing != null)
            existing.AddOne();
        else
            slots.Add(new InventorySlot { flower = flower, isSeed = false, amount = 1 });
    }

    public void RemoveOne(InventorySlot slot)
    {
        slot.RemoveOne();
    }
}