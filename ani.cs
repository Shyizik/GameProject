using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Скрипт для керування анімацією руху і стрибка персонажа
public class ani : MonoBehaviour
{
    // Приватне посилання на компонент Animator
    private Animator _animator;

    // Властивість для встановлення стану руху (ззовні можна тільки встановлювати)
    public bool IsMoving { private get; set; }

    // Властивість для встановлення стану стрибка (ззовні можна тільки встановлювати)
    public bool IsJumping { private get; set; }

    // Метод Start викликається при запуску сцени
    private void Start()
    {
        // Отримуємо компонент Animator у дочірньому об'єкті
        _animator = GetComponentInChildren<Animator>();
    }

    // Метод Update викликається кожен кадр
    private void Update()
    {
        // Оновлюємо параметр "IsMoving" у Animator відповідно до властивості
        _animator.SetBool("IsMoving", IsMoving);
    }

    // Метод для запуску анімації стрибка
    public void Jump()
    {
        // Викликаємо тригер "Jump" у Animator
        _animator.SetTrigger("Jump");
    }
}
