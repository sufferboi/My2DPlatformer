using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private Rigidbody2D myRigidBody;

    private Animator myAnimator;

    //serializeField means that you can access the array from inspector.
    [SerializeField]
    private float MovementSpeed;

    //array named attack that cannot be
    //accessed from other functions unless directly referenced.
    private bool attack;

    private bool FacingRight;

    [SerializeField]
    private Transform[] GroundPoints;

    [SerializeField]
    private float GroundRadius;

    //serializeField means that you can access the array from inspector.
    [SerializeField]
    private LayerMask WhatIsGround;

    private bool isGrounded;

    //jumping is either true or false.
    private bool Jumping;

    [SerializeField]
    private bool AirControl;

    [SerializeField]
    private float JumpForce;

    // Use this for initialization
	void Start ()
    {
        FacingRight = true;
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
	}
    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }
    // Update is called sequentially.
    void FixedUpdate()
    {
        //gets current value of horizontal(x value)
        float horizontal = Input.GetAxis("Horizontal");

        isGrounded = IsGrounded();

        //this calls upon HandleMovement function.
        HandleMovement(horizontal);
        
        //this calls upon the flip function.
        Flip(horizontal);
        
        //calls upon handle attacks function.
        HandleAttacks();

        HandleLayers();
        
        //this resets position back to base value(idle).
        ResetValues();
	}
    //this function handles all movements.
    private void HandleMovement(float horizontal)
    {
        if (myRigidBody.velocity.y < 0)
        {
            //activates land animation.
            myAnimator.SetBool("land", true);
        }
        //this checks the animator and then sets current base value to 0 = idle.
        if (!this.myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("attack1")&& (isGrounded || AirControl))
        {
            //this allows my play to move on a horizontal axis.
            myRigidBody.velocity = new Vector2(horizontal * MovementSpeed, myRigidBody.velocity.y);
        }

        if (isGrounded && Jumping)
        {
            isGrounded = false;
            myRigidBody.AddForce(new Vector2(0, JumpForce));
            //activates the jump animation.
            myAnimator.SetTrigger("jump");
        }

        myAnimator.SetFloat("speed", Mathf.Abs(horizontal));
    }

    private void HandleAttacks()
    {
        if (attack)
        {
            //triggers the animation(attack1).
            myAnimator.SetTrigger("attack1");

            //if attack is called upon then velocity must be 0.
            myRigidBody.velocity = Vector2.zero;
        }

    }

    private void HandleInput()
    {
        //this tells game that jumping function is activated when keydown space is pressed.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jumping = true;
        }
        
        //this tells game that attack animation is activated by keydown M.
        if (Input.GetKeyDown(KeyCode.M))
        {
            attack = true;
        }
    }

    //function takes in the horizontal values.
    private void Flip(float horizontal)
    {
        //if the inputs of horizontal are >0 the player remains in default position.
        //if inputs of horizontal <0 the player is flipped.
        if (horizontal > 0 && !FacingRight || horizontal < 0 && FacingRight)
        {
            FacingRight = !FacingRight;

            Vector3 theScale = transform.localScale;
            theScale.x *= -1;

            transform.localScale = theScale;
        }

    }

    //this stops a function repeatedly happening.
    private void ResetValues()
    {
        attack = false;
        Jumping = false;
    }

    //function lets game know when rigidbody is touching the ground.
    private bool IsGrounded()
    {
        //2 potential velocity.y = 0 so much define between the two.
        if (myRigidBody.velocity.y <= 0)
        {
            //these are the 3 gameobjects we created.
            foreach (Transform point in GroundPoints)
            {
                //indicates how close the player must be to the ground in order to jump again.
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, GroundRadius, WhatIsGround);
                //loop so that it checks everytime the distance between gameobjects and ground.
                for (int i = 0; i < colliders.Length; i++)
                {
                    if (colliders[i].gameObject !=gameObject)
                    {
                        myAnimator.ResetTrigger("jump");
                        myAnimator.SetBool("land", false);
                        return true;
                    }

                }
            }

        }
        return false;
    }

    //changes the base layers so it can change from 'GroundLayer' to 'AirLayer'.
    private void HandleLayers()
    {
        //this says that if the player isn't grounded then the airlayer must be enabled.
        if (!isGrounded)
        {
            myAnimator.SetLayerWeight(1, 1);
        }
        //else the ground layer is enabled.
        else
        {
            myAnimator.SetLayerWeight(1, 0);
        }
        
    }
}
