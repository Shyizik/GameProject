using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// ������ ��� �������� �� �������� ����� ��� ���� ������ � ������
public class portal : MonoBehaviour
{
    // ����� �����������, ���� ������ ��'��� ������� � ������ �������
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ���� ��'� ��'���� � "Sprite" (�������)
        if (collision.gameObject.name == "Sprite")
        {
            // ����������� �������� ����� � ������ (build index + 1)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
