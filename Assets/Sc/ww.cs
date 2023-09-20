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
        textMoveSpeed.text = "이동속도: " + playerContoller.moveSpeed;
        textJumpSpeed.text = "점프력: " + playerContoller.jumpSpeed;
    }
}
