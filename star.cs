using UnityEngine;

// Скрипт для знищення снаряду після часу або при зіткненні
public class star : MonoBehaviour
{
    // Час життя снаряду до самознищення
    public float lifeTime = 3f;

    void Start()
    {
        // Автоматично знищити об'єкт через lifeTime секунд
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Якщо стикнулись з ворогом, пасткою або стіною — знищити
        if (collision.CompareTag("Enemy") || collision.CompareTag("trap") || collision.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }

        // Альтернатива: знищити при будь-якому зіткненні, крім Player або інших снарядів
        // if (!collision.CompareTag("Player") && !collision.CompareTag("star"))
        //     Destroy(gameObject);
    }
}
