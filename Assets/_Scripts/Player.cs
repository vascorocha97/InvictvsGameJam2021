using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PhysicsObject
{
    private float movementInput;

    [Header("Movement Settings")]
    [SerializeField] private float jumpSpeed = 10f;
    [SerializeField] private float moveSpeed = 3f;


    //Singleton Instantiation
    private static Player instance;
    public static Player Instance
    {
        get
        {
            if (instance == null) instance = GameObject.FindObjectOfType<Player>();
            return instance;
        }
    }

    void Start()
    {

    }


    void Update()
    {
        //Movement
        ReadMoveInput();
        Move();
        FlipSprite();

        //Jump
        HandleJumpInput();
    }


    //Move
    private void ReadMoveInput()
    {
        movementInput = Input.GetAxisRaw("Horizontal");
        Debug.Log(movementInput);
    }
    private void Move()
    {
        targetVelocity = new Vector2(movementInput * moveSpeed, 0);
    }
    private void FlipSprite()
    {
        if (targetVelocity.x < -.01f)
        {
            transform.localScale = new Vector2(-1, 1);
        }
        else if (targetVelocity.x > .01f)
        {
            transform.localScale = new Vector2(1, 1);
        }
    }

    //Jump
    private void HandleJumpInput()
    {
        if (Input.GetButtonDown("Jump")) 
        {
            Jump();
        }
    }
    private void Jump()
    {
        if (grounded)
        {
            velocity.y = jumpSpeed;
            //Apply velocity as if the ground is flat
            groundNormal = new Vector2(0f, 1f);
        }
    }
}
