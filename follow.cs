using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������, �� ����� ��'��� (���������, ������ ��� �����) �������� �� ����� ��'����� (Sprite)
public class follow : MonoBehaviour
{
    // ��'���, �� ���� ������� ������� (������������ � ���������)
    [SerializeField] private Transform Sprite;

    // Start ����������� ���� ��� �� ������� (�� ��������������� ���)
    void Start()
    {
        
    }

    // Update ����������� ����� ����
    void Update()
    {
        // ������� ������� ��'����, �� ����� ������ ��� ������, ��� �������� �� Sprite �� X �� Y.
        // Z-���������� ���������� �������� (��� �� �������, ���������, ��������� ������)
        transform.position = new Vector3(Sprite.position.x, Sprite.position.y, transform.position.z);
    }
}
