using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������ ��� ��������� �������� ���� � ������� ���������
public class ani : MonoBehaviour
{
    // �������� ��������� �� ��������� Animator
    private Animator _animator;

    // ���������� ��� ������������ ����� ���� (����� ����� ����� �������������)
    public bool IsMoving { private get; set; }

    // ���������� ��� ������������ ����� ������� (����� ����� ����� �������������)
    public bool IsJumping { private get; set; }

    // ����� Start ����������� ��� ������� �����
    private void Start()
    {
        // �������� ��������� Animator � ���������� ��'���
        _animator = GetComponentInChildren<Animator>();
    }

    // ����� Update ����������� ����� ����
    private void Update()
    {
        // ��������� �������� "IsMoving" � Animator �������� �� ����������
        _animator.SetBool("IsMoving", IsMoving);
    }

    // ����� ��� ������� ������� �������
    public void Jump()
    {
        // ��������� ������ "Jump" � Animator
        _animator.SetTrigger("Jump");
    }
}
