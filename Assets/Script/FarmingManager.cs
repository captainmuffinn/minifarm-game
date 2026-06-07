using UnityEngine;
using UnityEngine.Tilemaps;

public class FarmingManager : MonoBehaviour
{
    [SerializeField] private Tilemap groundTilemap;
    [SerializeField] private TileBase grassTile;
    [SerializeField] private TileBase farmlandTile;
    [SerializeField] private Transform player;
    [SerializeField] private int maxReach = 3;
    [SerializeField] private Transform flowers;

    void Start()
    {
        FlowerManager.Instance.SetupTilemap(groundTilemap, farmlandTile);
        FlowerManager.Instance.RefreshScene(flowers);
    }
    void Update()
    {
        Vector2 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mouseWorld, Vector2.zero);
        Vector3Int tilePos = GetMouseTilePos();

        if (Input.GetMouseButtonDown(0))
        {
            if (hit.collider != null) return;
            if (!IsInReach(tilePos)) return;

            if (groundTilemap.GetTile(tilePos) == grassTile)
                FlowerManager.Instance.SetFarmland(tilePos);
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (!IsInReach(tilePos)) return;
            if (groundTilemap.GetTile(tilePos) != farmlandTile) return;
            if (hit.collider != null) return;

            TryPlant(tilePos);
        }
    }

    void TryPlant(Vector3Int tilePos)
    {
        InventorySlot active = InventoryUI.Instance.activeSlot;
        if (active == null || active.GetAmount() <= 0) return;
        if (active.flower == null || !active.isSeed) return;

        Vector3 worldPos = groundTilemap.GetCellCenterWorld(tilePos);
        FlowerManager.Instance.PlantCrop(worldPos, active.flower);
        active.RemoveOne();
        InventoryUI.Instance.RefreshInventory();
        InventoryUI.Instance.RefreshActiveItem();
    }

    Vector3Int GetMouseTilePos()
    {
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorld.z = 0;
        return groundTilemap.WorldToCell(mouseWorld);
    }

    bool IsInReach(Vector3Int tilePos)
    {
        Vector3 tileWorld = groundTilemap.GetCellCenterWorld(tilePos);
        return Vector3.Distance(player.position, tileWorld) <= maxReach;
    }
}