using UnityEngine;
using UnityEngine.Tilemaps;

public class Smile52673_TilemapManager : MonoBehaviour
{
    public Tilemap tilemap;
    public int width;
    public int height;

    private TileData[,] tileArray;

    void Start()
    {
        tileArray = new TileData[width, height]; // Ÿ�� �����͸� ������ �迭
        LoadTilemapToArray();
    }

    void LoadTilemapToArray()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector3Int tilePosition = new Vector3Int(x, y, 0);
                TileBase tile = tilemap.GetTile(tilePosition);

                bool isWalkable = !tile.name.Contains("Black"); // ������ Ÿ���� �̵� �Ұ� Ÿ�Ϸ� ����
                tileArray[x, y] = new TileData(tile, x, y, isWalkable);
            }
        }
    }

    public bool IsValidPosition(Vector2Int position)
    {
        // 1 ���� Ȯ��
        if (position.x < 0 || position.x >= width || position.y < 0 || position.y >= height)
            return false;

        // 2 Ư�� Ÿ���� �̵� �Ұ� ó�� (��: ��)
        TileData tile = tileArray[position.x, position.y];
        return tile != null && tile.isWalkable;
    }

    public Vector2Int WorldToGrid(Vector3 worldPosition)
    {
        Vector3Int gridPos = tilemap.WorldToCell(worldPosition);
        return new Vector2Int(gridPos.x, gridPos.y);
    }
}

// Ÿ�� ������ �����ϴ� ������ Ŭ����
public class TileData
{
    public TileBase tile;
    public int x, y;
    public bool isWalkable;  // �̵� ������ Ÿ������ ����

    public TileData(TileBase tile, int x, int y, bool isWalkable)
    {
        this.tile = tile;
        this.x = x;
        this.y = y;
        this.isWalkable = isWalkable;  // �⺻�� (���� �� Ÿ���̸� false�� ���� ����)
    }
}