using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class Smile52673_PlayerMove : MonoBehaviour
{
    public Smile52673_TilemapManager tilemapManager;
    public Vector2Int gridPosition = new Vector2Int(1, 1); // 현재 타일 좌표
    public Smile52673_EnemyAI[] enemies;
    public GameObject bulletPrefab;
    public float bulletSpeed = 5f;
    public GameObject clearText;

    public int maxBullets = 1;
    public int bullets = 0;

    void Start()
    {
        UpdateCharacterPosition();
    }

    void Update()
    {
        Vector2Int inputDirection = Vector2Int.zero;

        if (Input.GetKeyDown(KeyCode.UpArrow)) inputDirection = new Vector2Int(0, 1);
        if (Input.GetKeyDown(KeyCode.DownArrow)) inputDirection = new Vector2Int(0, -1);
        if (Input.GetKeyDown(KeyCode.LeftArrow)) inputDirection = new Vector2Int(-1, 0);
        if (Input.GetKeyDown(KeyCode.RightArrow)) inputDirection = new Vector2Int(1, 0);

        if (inputDirection != Vector2Int.zero)
        {
            Vector2Int newGridPosition = gridPosition + inputDirection;
            
            // 이동하면 총알 장전
            bullets = maxBullets;

            if (tilemapManager.IsValidPosition(newGridPosition))
            {
                gridPosition = newGridPosition;
                UpdateCharacterPosition();

                // 존재하는 Enemy만 리스트에 유지 (삭제된 Enemy는 제거)
                enemies = enemies.Where(enemy => enemy != null).ToArray();

                // 플레이어가 이동한 후 모든 적의 경로 갱신 및 이동
                foreach (var enemy in enemies)
                {
                    enemy.UpdatePath();  // 적의 경로 갱신
                    enemy.MoveOneStep(); // 적을 한 칸 이동
                }
            }
        }

        // 총알 발사 (wasd)
        if (Input.GetKeyDown(KeyCode.W)) Shoot(Vector2Int.up);
        if (Input.GetKeyDown(KeyCode.S)) Shoot(Vector2Int.down);
        if (Input.GetKeyDown(KeyCode.A)) Shoot(Vector2Int.left);
        if (Input.GetKeyDown(KeyCode.D)) Shoot(Vector2Int.right);

        // 승리 조건. 모든 적을 제거하면 다음 스테이지로 이동
        // 현재는 스테이지가 하나라 다시 시작
        if (enemies[0] == null)
        {
            clearText.SetActive(true);
            StartCoroutine(RestartLevelAfterDelay());
        }
    }

    void Shoot(Vector2Int direction)
    {
        if (bullets <= 0) return;

        Vector3 spawnPos = transform.position; // 플레이어 위치에서 발사
        GameObject bullet = Instantiate(bulletPrefab, spawnPos, Quaternion.identity);

        Smile52673_Bullet bulletScript = bullet.GetComponent<Smile52673_Bullet>();
        bulletScript.direction = direction;
        bulletScript.speed = bulletSpeed;
        bullets--;
    }


    void UpdateCharacterPosition()
    {
        transform.position = tilemapManager.tilemap.GetCellCenterWorld((Vector3Int)gridPosition);
    }

    // 패배 조건. 스테이지 재시작
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            StartCoroutine(RestartLevelAfterDelay());
        }
    }

    IEnumerator RestartLevelAfterDelay()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
