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
        tileArray = new TileData[width, height]; // 타일 데이터를 저장할 배열
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

                bool isWalkable = !tile.name.Contains("Black"); // 검은색 타일은 이동 불가 타일로 설정
                tileArray[x, y] = new TileData(tile, x, y, isWalkable);
            }
        }
    }

    public bool IsValidPosition(Vector2Int position)
    {
        // 1 범위 확인
        if (position.x < 0 || position.x >= width || position.y < 0 || position.y >= height)
            return false;

        // 2 특정 타일을 이동 불가 처리 (예: 벽)
        TileData tile = tileArray[position.x, position.y];
        return tile != null && tile.isWalkable;
    }

    public Vector2Int WorldToGrid(Vector3 worldPosition)
    {
        Vector3Int gridPos = tilemap.WorldToCell(worldPosition);
        return new Vector2Int(gridPos.x, gridPos.y);
    }
}

// 타일 정보를 저장하는 데이터 클래스
public class TileData
{
    public TileBase tile;
    public int x, y;
    public bool isWalkable;  // 이동 가능한 타일인지 여부

    public TileData(TileBase tile, int x, int y, bool isWalkable)
    {
        this.tile = tile;
        this.x = x;
        this.y = y;
        this.isWalkable = isWalkable;  // 기본값 (이후 벽 타일이면 false로 설정 가능)
    }
}