using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smile52673_EnemyAI : MonoBehaviour
{
    public Smile52673_TilemapManager tilemapManager;
    public Transform player;
    public int moveDistance = 1; // Inspector에서 설정 가능 (1~2칸 이동)
    public float stepDelay = 0.2f; // 각 칸 이동 시 대기 시간 (0.2초)

    private Vector2Int gridPosition;
    private Smile52673_Pathfinding pathfinding;
    private List<Vector2Int> path;

    void Start()
    {
        gridPosition = tilemapManager.WorldToGrid(transform.position);
        pathfinding = new Smile52673_Pathfinding(tilemapManager, tilemapManager.width, tilemapManager.height);
        // 태그 누락 방지를 위해 Enemy 태그 한번 더 설정
        gameObject.tag = "Enemy";
    }

    public void UpdatePath()
    {
        Vector2Int playerPosition = tilemapManager.WorldToGrid(player.position);
        path = pathfinding.FindPath(gridPosition, playerPosition);
    }

    public void MoveOneStep()
    {
        if (path != null && path.Count > 0)
        {
            StartCoroutine(MoveSteps()); // 한 칸씩 이동하는 코루틴 실행
        }
    }

    private IEnumerator MoveSteps()
    {
        int steps = Mathf.Min(moveDistance, path.Count); // 이동할 최대 칸 수
        for (int i = 0; i < steps; i++)
        {
            if (i >= path.Count) break; // 이동할 칸이 부족하면 종료
            gridPosition = path[i]; // 다음 위치로 이동
            transform.position = tilemapManager.tilemap.GetCellCenterWorld((Vector3Int)gridPosition);
            yield return new WaitForSeconds(stepDelay); // 0.2초 대기 후 다음 칸 이동
        }
        path.Clear(); // 이동 후 경로 초기화
    }
}