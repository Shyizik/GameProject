using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������, ���� ����� ������ (������� ����) ����� ������
public class FireBallThrow : MonoBehaviour
{
    // ��������� ������
    private Rigidbody2D body;

    // �������� ���� ������� ��� (����� �������� � ���������)
    [SerializeField] private float FireSpeed = 5f; // 05f � ���� �����������

    // ��� ����� ������� (�� ���������������, ��� ����� �)
    private float LifeTime;

    // �����������
    void Start()
    {
        // �������� Rigidbody2D, ��� �������� �������
        body = GetComponent<Rigidbody2D>();
    }

    // Update ����������� ����� ����
    void Update()
    {
        // ���������� ������� �������� � �������� transform.right (������ �� X)
        body.velocity = transform.right * FireSpeed;
    }
}
