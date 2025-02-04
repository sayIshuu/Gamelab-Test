using System.Collections.Generic;
using UnityEngine;

public class Smile52673_Pathfinding : MonoBehaviour
{
    private Smile52673_TilemapManager tilemapManager;
    private int width, height;

    public Smile52673_Pathfinding(Smile52673_TilemapManager tilemapManager, int width, int height)
    {
        this.tilemapManager = tilemapManager;
        this.width = width;
        this.height = height;
    }

    public List<Vector2Int> FindPath(Vector2Int start, Vector2Int target)
    {
        List<Node> openList = new List<Node>();
        HashSet<Node> closedList = new HashSet<Node>();

        Node[,] nodeGrid = new Node[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                nodeGrid[x, y] = new Node(new Vector2Int(x, y));
            }
        }

        Node startNode = nodeGrid[start.x, start.y];
        Node targetNode = nodeGrid[target.x, target.y];

        openList.Add(startNode);

        while (openList.Count > 0)
        {
            Node currentNode = openList[0];
            for (int i = 1; i < openList.Count; i++)
            {
                if (openList[i].FCost < currentNode.FCost ||
                    (openList[i].FCost == currentNode.FCost && openList[i].HCost < currentNode.HCost))
                {
                    currentNode = openList[i];
                }
            }

            openList.Remove(currentNode);
            closedList.Add(currentNode);

            if (currentNode.Position == target)
            {
                return RetracePath(startNode, targetNode);
            }

            foreach (Vector2Int direction in new Vector2Int[] { Vector2Int.up, Vector2Int.down, Vector2Int.left, Vector2Int.right })
            {
                Vector2Int neighborPos = currentNode.Position + direction;
                if (!tilemapManager.IsValidPosition(neighborPos)) continue; // 벽 체크

                Node neighbor = nodeGrid[neighborPos.x, neighborPos.y];

                if (closedList.Contains(neighbor)) continue;

                int newMovementCost = currentNode.GCost + 1;

                if (newMovementCost < neighbor.GCost || !openList.Contains(neighbor))
                {
                    neighbor.GCost = newMovementCost;
                    neighbor.HCost = GetHeuristic(neighbor.Position, target);
                    neighbor.Parent = currentNode;

                    if (!openList.Contains(neighbor))
                        openList.Add(neighbor);
                }
            }
        }

        return new List<Vector2Int>(); // 경로 없음
    }

    private List<Vector2Int> RetracePath(Node startNode, Node endNode)
    {
        List<Vector2Int> path = new List<Vector2Int>();
        Node currentNode = endNode;

        while (currentNode != startNode)
        {
            path.Add(currentNode.Position);
            currentNode = currentNode.Parent;
        }

        path.Reverse();
        return path;
    }

    private int GetHeuristic(Vector2Int a, Vector2Int b)
    {
        return Mathf.Abs(a.x - b.x) + Mathf.Abs(a.y - b.y);
    }

    private class Node
    {
        public Vector2Int Position;
        public int GCost, HCost;
        public int FCost => GCost + HCost;
        public Node Parent;

        public Node(Vector2Int position)
        {
            Position = position;
            GCost = int.MaxValue;
            HCost = 0;
            Parent = null;
        }
    }
}

