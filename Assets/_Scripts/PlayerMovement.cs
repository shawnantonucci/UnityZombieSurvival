using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator anim;
    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    public Camera cam;
    public Transform playerGFX;

    Vector2 movement;
    Vector2 mousePos;

    private Vector2 lookDirection;
    private float angle;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Vector3 characterScale = transform.localScale;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if(movement.x == 1 || movement.x == -1 || movement.y == 1 || movement.y == -1)
        {
            anim.SetFloat("Speed", moveSpeed);
        } else if(movement.x == 0 )
        {
            anim.SetFloat("Speed", 0f);
        }

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
