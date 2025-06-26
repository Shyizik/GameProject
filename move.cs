using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Скрипт для керування рухом персонажа, стрибками, анімацією та платформами
public class move : MonoBehaviour
{
    [SerializeField] private float _speed; // Швидкість руху
    [SerializeField] private float _jump;  // Сила стрибка (не використовується прямо тут)

    public Animator animator; // Посилання на Animator (для керування анімацією)

    private Vector3 _input; // Вхід користувача
    private Rigidbody2D body; // (не використовується, можеш видалити)
    private bool _IsMoving;   // Чи рухається гравець
    private bool _IsJumping;  // Чи стрибає гравець

    private Rigidbody2D _rigidbody;     // Rigidbody2D для фізики
    private ani _animations;            // Посилання на інший скрипт з анімацією (ani.cs)
    [SerializeField] private SpriteRenderer _Sprite; // Для віддзеркалення спрайта

    private void Start()
    {
        // Ініціалізація компонентів
        _rigidbody = GetComponent<Rigidbody2D>();
        _animations = GetComponentInChildren<ani>();
    }

    private void Update()
    {
        // Рух гравця
        Move();

        // Повернення в головне меню (сцена 0) при натисканні Escape
        if (Input.GetKeyDown("escape"))
        {
            SceneManager.LoadScene(0);
        }

        // Стрибок, якщо гравець на землі (перевірка через y-швидкість)
        if (Input.GetKeyDown("space") && _rigidbody.velocity.y == 0f)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 3f);
        }

        // Передача стану руху в скрипт ani.cs
        _animations.IsMoving = _IsMoving;

        // Керування анімацією стрибка
        if (_rigidbody.velocity.y > 0.1f)
        {
            animator.SetBool("IsJumping", true);
        }
        else if (_rigidbody.velocity.y == 0f)
        {
            animator.SetBool("IsJumping", false);
        }
    }

    private void Move()
    {
        // Зчитування горизонтального вводу (A/D або ←/→)
        _input = new Vector2(Input.GetAxis("Horizontal"), 0);

        // Переміщення об'єкта з врахуванням швидкості та часу
        transform.position += _input * _speed * Time.deltaTime;

        // Встановлюємо прапорець _IsMoving
        _IsMoving = _input.x != 0 ? true : false;

        // Дзеркально відображаємо спрайт, якщо напрямок змінюється
        if (_IsMoving)
        {
            _Sprite.flipX = _input.x > 0 ? false : true;
        }
    }

    // Коли гравець торкається платформи
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Прив'язка до рухомої платформи по імені (горизонтальна або вертикальні)
        if (collision.gameObject.name.Equals("platform hor") ||
            collision.gameObject.name.Equals("platform vert1") ||
            collision.gameObject.name.Equals("platform vert"))
        {
            this.transform.parent = collision.transform;
        }
    }

    // Коли гравець сходить з платформи — від'єднується
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("platform hor") ||
            collision.gameObject.name.Equals("platform vert1") ||
            collision.gameObject.name.Equals("platform vert"))
        {
            this.transform.parent = null;
        }
    }
}
