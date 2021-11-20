using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PhysicsObject
{
    private float movementInput;

    [Header("Weight Settings")]
    [SerializeField] private float weight = 0f;
    public float maxWeight = 50f;
    public float minWeight = 0f;
    [SerializeField] private Sprite[] spriteList;

    [Header("Movement Settings")]
    [SerializeField] private float jumpSpeed = 10f;
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private bool canMove = true;

    [Header("Collectables")]
    public int foodCollected = 0;

    [Header("Animation Settings")]
    [SerializeField] private Animator animator;


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

        //Animation
        HandleWalkAnim();
    }


    //Move
    private void ReadMoveInput()
    {
        movementInput = Input.GetAxisRaw("Horizontal");
        if (movementInput > 0)
        {
            movementInput = 1;
        }
        else if (movementInput < 0)
        {
            movementInput = -1;
        }
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
    public void Freeze(bool isFrozen) 
    {
        canMove = isFrozen;
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
            PlayJumpSound();
            TriggerJumpAnim();
        }
    }

    //Inventory and Weight
    public void IncreaseWeight()
    {
        if (weight < maxWeight)
        {
            weight += 10;
            UpdatePlayerSprite();
        }
    }
    public void DecreaseWeight()
    {
        if (weight > minWeight)
        {
            weight -= 10;
            UpdatePlayerSprite();
        }
    }
    public float GetWeight()
    {
        return this.weight;
    }
    private void UpdatePlayerSprite()
    {
        switch (weight)
        {
            case 0:
                //
                break;
            case 10:
                //
                break;
            case 20:
                //
                break;
            case 30:
                //
                break;
            case 40:
                //
                break;
            case 50:
                //
                break;
            default:
                break;
        }

    }

    //Animations
    private void HandleWalkAnim()
    {
        if (grounded && movementInput != 0)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }
    private void TriggerJumpAnim()
    {
        animator.SetTrigger("Jump");
    }

    //Audio
    private void PlayJumpSound()
    {
        AkSoundEngine.PostEvent("cckJump", this.gameObject);
    }
    public void PlayFootsteps()
    {
        AkSoundEngine.PostEvent("cckStep", this.gameObject);
    }
}
