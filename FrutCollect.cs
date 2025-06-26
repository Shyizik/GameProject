using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;              // ��� ������ � UI (Text)
using UnityEngine.SceneManagement; // (���� �� ���������������, ��� ���� ���� ��� ���������������� ���� ����)

// ������ ��� �������� ������ �� ��������� ����
public class FrutCollect : MonoBehaviour
{
    // ˳������� ����
    private int PointCounter = 0;

    // ���������� Rigidbody �� Animator (�� ���������������� ����� � ����� ������, ��� ������ ���� ������ �����)
    private Rigidbody2D body;
    private Animator anim;

    // ��������� �� UI Text, �� ���������� ������� ������� ������
    [SerializeField] private Text Fruits;

    // ����� ����������� ��� ���� � ������
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ���� ��'��� �� ��� "fruit"
        if (collision.gameObject.CompareTag("fruit"))
        {
            // �������� ��������
            PointCounter++;

            // ������� �����
            Destroy(collision.gameObject);

            // ��������� ����� �� �����
            Fruits.text = "Fruits : " + PointCounter;
        }
    }
}
