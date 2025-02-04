using UnityEngine;

public class Smile52673_WallTilemap : MonoBehaviour
{
    void Start()
    {
        // 태그 누락 방지를 위해 Wall 태그 한번 더 설정
        gameObject.tag = "Wall";
    }
}
