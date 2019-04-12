using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum PlayerStates
    {
        Jumping,
        Running,
        Dashing,
    };

    PlayerStates playerState = PlayerStates.Running;

    public float jumpAmplitude = 15.0f;
    //Doesn't work when it's a variable idk why, go change value manually
    public float fallSpeedMultiplier = 0.75f;

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        switch (playerState)
        {
            case PlayerStates.Running:
                {
                    if (Input.GetKey(KeyCode.Space))
                    {
                        Jump();
                        playerState = PlayerStates.Jumping;
                    }

                    break;
                }
            case PlayerStates.Jumping:
                {
                    rb.velocity -= Vector2.up * 0.75f;
                    

                    break;
                } 
            case PlayerStates.Dashing:
                {


                    break;
                }

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (playerState == PlayerStates.Jumping && collision.gameObject.CompareTag("Ground"))
            playerState = PlayerStates.Running;
    }

    void Jump()
    {
        rb.velocity = Vector2.up * jumpAmplitude;
    }

}
