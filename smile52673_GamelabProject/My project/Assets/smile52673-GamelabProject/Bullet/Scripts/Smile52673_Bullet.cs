using UnityEngine;

public class Smile52673_Bullet : MonoBehaviour
{
    public float speed = 5f;
    public Vector2Int direction; // �Ѿ� ����
    private Smile52673_TilemapManager tilemapManager;

    void Start()
    {
        // Ÿ�ϸ� ����
        tilemapManager = FindObjectOfType<Smile52673_TilemapManager>();
    }

    void Update()
    {
        // �Ѿ� �̵� (Ÿ�� ����)
        Vector3 moveAmount = new Vector3(direction.x, direction.y, 0) * speed * Time.deltaTime;
        transform.position += moveAmount;

        /* ������ ���� ������ Ȯ���ϴ� �ڵ带 �����ϴ� ���������, 
         * ȿ������ ������ Ÿ�ϸʿ� �ݶ��̴��� �ְ� �Ʒ��� OnTriggerEnter2D���� ���� ó����.
        // Ÿ�ϸʿ��� ���� �Ѿ� ��ġ Ȯ��
        Vector2Int gridPos = tilemapManager.WorldToGrid(transform.position);

        // ���� ������ �Ѿ� ����
        if (!tilemapManager.IsValidPosition(gridPos))
        {
            Destroy(gameObject);
        }
        */
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // ���� ���߸� �� ����
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject); // �� ����
            Destroy(gameObject); // �Ѿ� ����
        }
        else if (collision.CompareTag("Wall"))
        {
            Destroy(gameObject); // �Ѿ� ����
        }
    }
}
