using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������ ��� ������ � ��� ��� ��������� ������
public class exit : MonoBehaviour
{
    // ����� ����������� � ������ (���������, � UI)
    public void QuitGameCall()
    {
        // ������� ������ ������� (������ ���� � ���������� .exe ����, �� � �������� Unity)
        Application.Quit();
    }
}
