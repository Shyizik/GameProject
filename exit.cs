using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Скрипт для виходу з гри при натисканні кнопки
public class exit : MonoBehaviour
{
    // Метод викликається з кнопки (наприклад, у UI)
    public void QuitGameCall()
    {
        // Завершує роботу додатку (працює лише в побудованій .exe версії, не в редакторі Unity)
        Application.Quit();
    }
}
