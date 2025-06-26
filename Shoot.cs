using UnityEngine;

// ������ ��� ��������� ������� ("star") ��� ��������� ������ F
public class Shoot : MonoBehaviour
{
    public Transform shotPos;                     // ����� ����� ������� (spawn point)
    public GameObject starPrefab;                 // ������ ��� ��� �������
    public float projectileSpeed = 6f;            // �������� ������� ���

    [SerializeField] private SpriteRenderer playerSprite; // ������ ������ (��� �������� ��������)

    void Update()
    {
        // ��� ��������� ������ F
        if (Input.GetKeyDown(KeyCode.F))
        {
            // 1) ��������� ���� � ������� shotPos
            GameObject bullet = Instantiate(starPrefab, shotPos.position, Quaternion.identity);

            // 2) ��������� ��������: ���� ������� �������� ������ � -1, ������ 1
            float dir = playerSprite.flipX ? -1f : 1f;

            // 3) ���������� �������� ��� ����� Rigidbody2D
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
                rb.velocity = new Vector2(dir * projectileSpeed, 0f);

            // 4) ³������������ ����, ���� ������ ���� (��� ��������� ���������)
            if (dir < 0)
            {
                Vector3 s = bullet.transform.localScale;
                s.x = -Mathf.Abs(s.x);  // ������ X ����������
                bullet.transform.localScale = s;
            }

            Debug.Log($"Shoot dir = {dir}"); // ��� ��� ������
        }
    }
}
