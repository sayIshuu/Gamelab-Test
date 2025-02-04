using UnityEngine;

public class Smile52673_Bullet : MonoBehaviour
{
    public float speed = 5f;
    public Vector2Int direction; // 총알 방향
    private Smile52673_TilemapManager tilemapManager;

    void Start()
    {
        // 타일맵 참조
        tilemapManager = FindObjectOfType<Smile52673_TilemapManager>();
    }

    void Update()
    {
        // 총알 이동 (타일 기준)
        Vector3 moveAmount = new Vector3(direction.x, direction.y, 0) * speed * Time.deltaTime;
        transform.position += moveAmount;

        /* 기존에 만든 벽인지 확인하는 코드를 재사용하는 방법이지만, 
         * 효율성을 따져서 타일맵에 콜라이더를 넣고 아래의 OnTriggerEnter2D에서 같이 처리함.
        // 타일맵에서 현재 총알 위치 확인
        Vector2Int gridPos = tilemapManager.WorldToGrid(transform.position);

        // 벽을 만나면 총알 삭제
        if (!tilemapManager.IsValidPosition(gridPos))
        {
            Destroy(gameObject);
        }
        */
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // 적을 맞추면 적 삭제
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject); // 적 제거
            Destroy(gameObject); // 총알 제거
        }
        else if (collision.CompareTag("Wall"))
        {
            Destroy(gameObject); // 총알 제거
        }
    }
}
