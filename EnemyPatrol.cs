using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Клас відповідає за патрулювання ворога та його взаємодію з "пастками" (тег "star")
public class EnemyPatrol : MonoBehaviour
{
    // Швидкість руху ворога
    public float EnemySpeed = 3f;

    // Посилання на Rigidbody2D ворога
    public Rigidbody2D e_body;

    // LayerMask для перевірки, чи ворог на землі
    public LayerMask OnGroundControl;

    // Точка, з якої буде виконуватись перевірка на землю
    public Transform OnGroundCheck;

    // Напрямок руху ворога: true — праворуч, false — ліворуч
    private bool E_LookRight = true;

    // Змінна для зберігання результату Raycast
    RaycastHit2D hit;

    // Update викликається кожен кадр
    private void Update()
    {
        // Виконуємо Raycast вниз від точки OnGroundCheck на 1 одиницю, перевіряємо зіткнення з землею
        hit = Physics2D.Raycast(OnGroundCheck.position, -transform.up, 1f, OnGroundControl);
    }

    // FixedUpdate викликається з фіксованим інтервалом, використовується для фізики
    private void FixedUpdate()
    {
        // Якщо промінь зіткнувся з землею
        if (hit.collider != false)
        {
            // Якщо ворог дивиться праворуч — рухаємось праворуч
            if (E_LookRight)
            {
                e_body.velocity = new Vector2(EnemySpeed, 0f);
            }
            // Якщо ворог дивиться ліворуч — рухаємось ліворуч
            else
            {
                e_body.velocity = new Vector2(-EnemySpeed, 0f);
            }
        }
        // Якщо промінь НЕ зіткнувся з землею (обрив)
        else
        {
            // Міняємо напрямок
            E_LookRight = !E_LookRight;

            // Дзеркально відображаємо обʼєкт по осі X
            transform.localScale = new Vector3(-transform.localScale.x, 1f, 1f);
        }
    }

    // Метод викликається при вході в тригер
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Якщо доторкнулись до обʼєкта з тегом "star" — знищити ворога
        if (collision.CompareTag("star"))
        {
            Destroy(gameObject);
        }
    }
}
