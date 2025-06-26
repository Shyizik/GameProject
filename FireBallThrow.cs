using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Скрипт, який змушує снаряд (вогняну кулю) летіти вперед
public class FireBallThrow : MonoBehaviour
{
    // Компонент фізики
    private Rigidbody2D body;

    // Швидкість руху вогняної кулі (можна змінювати в інспекторі)
    [SerializeField] private float FireSpeed = 5f; // 05f — було неправильно

    // Час життя снаряда (не використовується, але змінна є)
    private float LifeTime;

    // Ініціалізація
    void Start()
    {
        // Отримуємо Rigidbody2D, щоб керувати фізикою
        body = GetComponent<Rigidbody2D>();
    }

    // Update викликається кожен кадр
    void Update()
    {
        // Присвоюємо постійну швидкість у напрямку transform.right (вперед по X)
        body.velocity = transform.right * FireSpeed;
    }
}
