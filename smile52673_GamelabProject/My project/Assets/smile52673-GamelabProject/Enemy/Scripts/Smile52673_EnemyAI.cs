using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smile52673_EnemyAI : MonoBehaviour
{
    public Smile52673_TilemapManager tilemapManager;
    public Transform player;
    public int moveDistance = 1; // Inspector���� ���� ���� (1~2ĭ �̵�)
    public float stepDelay = 0.2f; // �� ĭ �̵� �� ��� �ð� (0.2��)

    private Vector2Int gridPosition;
    private Smile52673_Pathfinding pathfinding;
    private List<Vector2Int> path;

    void Start()
    {
        gridPosition = tilemapManager.WorldToGrid(transform.position);
        pathfinding = new Smile52673_Pathfinding(tilemapManager, tilemapManager.width, tilemapManager.height);
        // �±� ���� ������ ���� Enemy �±� �ѹ� �� ����
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
            StartCoroutine(MoveSteps()); // �� ĭ�� �̵��ϴ� �ڷ�ƾ ����
        }
    }

    private IEnumerator MoveSteps()
    {
        int steps = Mathf.Min(moveDistance, path.Count); // �̵��� �ִ� ĭ ��
        for (int i = 0; i < steps; i++)
        {
            if (i >= path.Count) break; // �̵��� ĭ�� �����ϸ� ����
            gridPosition = path[i]; // ���� ��ġ�� �̵�
            transform.position = tilemapManager.tilemap.GetCellCenterWorld((Vector3Int)gridPosition);
            yield return new WaitForSeconds(stepDelay); // 0.2�� ��� �� ���� ĭ �̵�
        }
        path.Clear(); // �̵� �� ��� �ʱ�ȭ
    }
}