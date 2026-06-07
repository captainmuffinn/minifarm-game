using UnityEngine;

public class FlowerBehaviour : MonoBehaviour
{
    private Flower flower;
    private int currentStage;
    private SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void Init(Flower flower, int stage = 0)
    {
        this.flower = flower;
        currentStage = stage;
        UpdateStage(currentStage);
    }

    public void UpdateStage(int stage)
    {
        currentStage = stage;
        sr.sprite = flower.growthStages[currentStage];
    }

    public bool IsFullyGrown => currentStage >= flower.growthStages.Length - 1;

    void OnMouseDown()
    {
        if (IsFullyGrown)
            Harvest();
    }

    public void Harvest()
    {
        InventoryManager.Instance.AddHarvest(flower);
        InventoryUI.Instance?.RefreshInventory();
        FlowerManager.Instance.RemoveCrop(transform.position);
        Destroy(gameObject);
    }
}