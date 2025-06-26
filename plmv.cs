using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������ ��� ������ ���������, ��� �������� �� ����� ������� � ������ �� ������� ����
public class plmv : MonoBehaviour
{
    private Vector3 startPos;            // ��������� ������� ��������� (�����'��������� � Start)
    public Transform target;             // ʳ����� ����� (�������������� ����� ���������)
    public float speed = 2f;             // �������� ����
    public float pauseDuration = 1f;     // ������ ������ �� ������� ����

    private bool moveToTarget = true;    // ���� ��������� ���� (true � �� target, false � �� startPos)
    private bool isWaiting = false;      // �� ��������� ����� ����
    private float waitTimer = 0f;        // ˳������� ����������

    void Start()
    {
        // ������������ ��������� ������� ���������
        startPos = transform.position;
    }

    void Update()
    {
        // ���� ����� ���������� � �������� ������
        if (isWaiting)
        {
            waitTimer -= Time.deltaTime;

            // ���� ��� ���������� ����� � ������� ��������
            if (waitTimer <= 0f)
            {
                isWaiting = false;
                moveToTarget = !moveToTarget; // ̳����� ��������
            }

            return; // ���� ����� � �� ��������
        }

        // ��������� ������� �������
        Vector3 destination = moveToTarget ? target.position : startPos;

        // �������� �� ���
        transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);

        // ���� �������� ��� � ������ pauseDuration
        if (Vector3.Distance(transform.position, destination) < 0.01f)
        {
            isWaiting = true;
            waitTimer = pauseDuration;
        }
    }
}
