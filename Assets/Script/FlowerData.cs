[System.Serializable]
public class FlowerData
{
    public Flower flower;
    public int currentStage;
    public UnityEngine.Vector3 worldPosition;

    public bool IsFullyGrown => currentStage >= flower.growthStages.Length - 1;

    public void Grow()
    {
        if (!IsFullyGrown)
            currentStage++;
    }
}