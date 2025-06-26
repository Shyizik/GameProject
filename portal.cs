using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// —крипт дл€ переходу на наступну сцену при вход≥ гравц€ у портал
public class portal : MonoBehaviour
{
    // ћетод викликаЇтьс€, коли €кийсь об'Їкт входить у тригер порталу
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // якщо ≥м'€ об'Їкта Ч "Sprite" (гравець)
        if (collision.gameObject.name == "Sprite")
        {
            // «авантажити наступну сцену у списку (build index + 1)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
