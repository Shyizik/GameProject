using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Скрипт для рухомої платформи, яка рухається між двома точками з паузою на кожному кінці
public class plmv : MonoBehaviour
{
    private Vector3 startPos;            // Початкова позиція платформи (запам'ятовується в Start)
    public Transform target;             // Кінцева точка (встановлюється через інспектор)
    public float speed = 2f;             // Швидкість руху
    public float pauseDuration = 1f;     // Скільки чекати на кожному кінці

    private bool moveToTarget = true;    // Керує напрямком руху (true – до target, false – до startPos)
    private bool isWaiting = false;      // Чи платформа зараз чекає
    private float waitTimer = 0f;        // Лічильник очікування

    void Start()
    {
        // Запам’ятовуємо початкову позицію платформи
        startPos = transform.position;
    }

    void Update()
    {
        // Якщо зараз очікування — зменшуємо таймер
        if (isWaiting)
        {
            waitTimer -= Time.deltaTime;

            // Коли час очікування минув — змінюємо напрямок
            if (waitTimer <= 0f)
            {
                isWaiting = false;
                moveToTarget = !moveToTarget; // Міняємо напрямок
            }

            return; // Поки очікує — не рухається
        }

        // Визначаємо цільову позицію
        Vector3 destination = moveToTarget ? target.position : startPos;

        // Рухаємось до цілі
        transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);

        // Коли дістались цілі — чекаємо pauseDuration
        if (Vector3.Distance(transform.position, destination) < 0.01f)
        {
            isWaiting = true;
            waitTimer = pauseDuration;
        }
    }
}
