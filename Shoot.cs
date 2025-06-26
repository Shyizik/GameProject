using UnityEngine;

// Скрипт для створення снаряду ("star") при натисканні кнопки F
public class Shoot : MonoBehaviour
{
    public Transform shotPos;                     // Точка появи снаряду (spawn point)
    public GameObject starPrefab;                 // Префаб кулі або снаряду
    public float projectileSpeed = 6f;            // Швидкість польоту кулі

    [SerializeField] private SpriteRenderer playerSprite; // Спрайт гравця (для перевірки напрямку)

    void Update()
    {
        // При натисканні клавіші F
        if (Input.GetKeyDown(KeyCode.F))
        {
            // 1) Створюємо кулю в позиції shotPos
            GameObject bullet = Instantiate(starPrefab, shotPos.position, Quaternion.identity);

            // 2) Визначаємо напрямок: якщо гравець дивиться ліворуч — -1, інакше 1
            float dir = playerSprite.flipX ? -1f : 1f;

            // 3) Присвоюємо швидкість кулі через Rigidbody2D
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
                rb.velocity = new Vector2(dir * projectileSpeed, 0f);

            // 4) Віддзеркалюємо кулю, якщо летить вліво (щоб виглядала правильно)
            if (dir < 0)
            {
                Vector3 s = bullet.transform.localScale;
                s.x = -Mathf.Abs(s.x);  // робимо X негативним
                bullet.transform.localScale = s;
            }

            Debug.Log($"Shoot dir = {dir}"); // Лог для дебагу
        }
    }
}
