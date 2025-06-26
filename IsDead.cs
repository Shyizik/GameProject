using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Скрипт для обробки отримання шкоди, смерті та перезавантаження сцени
public class IsDead : MonoBehaviour
{
    private Rigidbody2D body;       // Компонент Rigidbody2D для блокування після смерті
    private Animator anim;          // Аніматор для запуску анімації смерті

    public int hp;                  // Поточне здоров’я гравця
    public Text hpT;                // Текст на UI для відображення HP
    public int hpDmg;               // Кількість шкоди при зіткненні з ворогом або пасткою

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        // Початкове оновлення тексту з HP
        hpT.text = "HP: " + hp.ToString();
    }

    // Викликається при зіткненні з об’єктом
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Якщо торкнулись пастки
        if (collision.gameObject.CompareTag("trap"))
        {
            hp -= hpDmg;
            hpT.text = "HP: " + hp.ToString();

            if (hp <= 0)
            {
                die();
            }
        }

        // Якщо торкнулись ворога
        if (collision.gameObject.CompareTag("Enemy"))
        {
            hp -= hpDmg;
            hpT.text = "HP: " + hp.ToString();

            if (hp <= 0)
            {
                die();
            }
        }

        // Якщо впали в зону з тегом "fall"
        if (collision.gameObject.CompareTag("fall"))
        {
            die();
        }
    }

    // Метод смерті гравця
    private void die()
    {
        // Запускає анімацію смерті та блокує фізику гравця
        anim.SetTrigger("IsDead");
        body.bodyType = RigidbodyType2D.Static;

        // (опціонально) Запускає перезапуск рівня через кілька секунд
        Invoke(nameof(RestartL), 2f); // ← можна додати, якщо хочеш автоперезапуск
    }

    // Перезапуск поточної сцени
    private void RestartL()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
