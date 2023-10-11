using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 4f;
    public float jumpSpeed = 400f;

    bool IsJump = false;

    Rigidbody2D rigidbody2D;

    public Vector2 restorePosition;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        restorePosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.W) && !IsJump)
        {
            IsJump = true;
            rigidbody2D.AddForce(Vector2.up * jumpSpeed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IsJump = false;

        if (collision.gameObject.CompareTag("장애물"))
        {
            transform.position = restorePosition;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("속도 증가 물약"))
        {
            moveSpeed += 3f;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.name.Equals("점프력 증가 물약"))
        {
            jumpSpeed += 100f;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.name.Equals("포탈"))
        {
            Destroy(collision.gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (collision.gameObject.CompareTag("세이브포인트"))
        {
            restorePosition = transform.position;
            Destroy(collision.gameObject);
        }
    }

}