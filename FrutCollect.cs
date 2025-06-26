using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;              // Для роботи з UI (Text)
using UnityEngine.SceneManagement; // (Поки не використовується, але може бути для перезавантаження рівня тощо)

// Скрипт для збирання фруктів та підрахунку очок
public class FrutCollect : MonoBehaviour
{
    // Лічильник очок
    private int PointCounter = 0;

    // Компоненти Rigidbody та Animator (не використовуються прямо в цьому скрипті, але можуть бути корисні пізніше)
    private Rigidbody2D body;
    private Animator anim;

    // Посилання на UI Text, де виводиться кількість зібраних фруктів
    [SerializeField] private Text Fruits;

    // Метод викликається при вході в тригер
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Якщо об'єкт має тег "fruit"
        if (collision.gameObject.CompareTag("fruit"))
        {
            // Збільшуємо лічильник
            PointCounter++;

            // Знищуємо фрукт
            Destroy(collision.gameObject);

            // Оновлюємо текст на екрані
            Fruits.text = "Fruits : " + PointCounter;
        }
    }
}
