using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Скрипт для повернення до попередньої (конкретно -4-ої) сцени в списку
public class restart_game : MonoBehaviour
{
    // Метод викликається з кнопки (наприклад, UI) для повернення на попередню сцену
    public void ReturnGameCall()
    {
        // Завантажити сцену на 4 позиції раніше в Build Index
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4);
    }
}
