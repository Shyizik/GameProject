using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// ������ ��� ���������� �� ���������� (��������� -4-�) ����� � ������
public class restart_game : MonoBehaviour
{
    // ����� ����������� � ������ (���������, UI) ��� ���������� �� ��������� �����
    public void ReturnGameCall()
    {
        // ����������� ����� �� 4 ������� ����� � Build Index
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4);
    }
}
