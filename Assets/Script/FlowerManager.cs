using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FlowerManager : MonoBehaviour
{
    public static FlowerManager Instance;

    [SerializeField] private GameObject cropPrefab;

    private List<FlowerData> plantedCrops = new();
    private Dictionary<Vector3, FlowerBehaviour> cropObjects = new();

    [SerializeField] private Transform flowersParent;

    private Tilemap groundTilemap;
    private TileBase farmlandTile;
    private HashSet<Vector3Int> farmlandTiles = new();

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

    public void SetupTilemap(Tilemap tilemap, TileBase farmland)
    {
        groundTilemap = tilemap;
        farmlandTile = farmland;
        RefreshTiles();
    }

    public void SetFarmland(Vector3Int pos)
    {
        farmlandTiles.Add(pos);
        groundTilemap.SetTile(pos, farmlandTile);
    }

    private void RefreshTiles()
    {
        foreach (Vector3Int pos in farmlandTiles)
            groundTilemap.SetTile(pos, farmlandTile);
    }


    public void PlantCrop(Vector3 worldPos, Flower flower)
    {
        if (cropObjects.ContainsKey(worldPos)) return;
        worldPos.y -= 0.25f;
        FlowerData data = new FlowerData
        {
            flower = flower,
            currentStage = 0,
            worldPosition = worldPos
        };

        plantedCrops.Add(data);
        SpawnCropObject(data);
    }

    public void GrowAll()
    {
        foreach (FlowerData data in plantedCrops)
        {
            data.Grow();

            if (cropObjects.TryGetValue(data.worldPosition, out FlowerBehaviour crop) && crop != null)
                crop.UpdateStage(data.currentStage);
        }
    }

    public void RemoveCrop(Vector3 worldPos)
    {
        plantedCrops.RemoveAll(c => c.worldPosition == worldPos);
        cropObjects.Remove(worldPos);
    }

    public void RefreshScene(Transform newFlowersParent)
    {
        flowersParent = newFlowersParent;
        cropObjects.Clear();
        foreach (FlowerData data in plantedCrops)
            SpawnCropObject(data);
    }

    private void SpawnCropObject(FlowerData data)
    {
        GameObject go = Instantiate(cropPrefab, data.worldPosition, Quaternion.identity, flowersParent);
        FlowerBehaviour behaviour = go.GetComponent<FlowerBehaviour>();
        behaviour.Init(data.flower, data.currentStage);
        cropObjects[data.worldPosition] = behaviour;
    }
}