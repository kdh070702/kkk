using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ww : MonoBehaviour
{
    public TMP_Text textMoveSpeed, textJumpSpeed;

    public PlayerController playerContoller;

    void Update()
    {
        textMoveSpeed.text = "�̵��ӵ�: " + playerContoller.moveSpeed;
        textJumpSpeed.text = "������: " + playerContoller.jumpSpeed;
    }
}
