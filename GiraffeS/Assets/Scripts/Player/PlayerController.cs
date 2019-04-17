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

    PlayerStates playerState = PlayerStates.Jumping;

    public float jumpAmplitude = 15.0f;
    //Doesn't work when it's a variable idk why, go change value manually
    public float fallSpeedMultiplier = 0.75f;
    public KeyCode jumpInput = KeyCode.Space;
    public GameObject Head;
    public bool Jumping = false;

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
                    Jumping = false;
                    if (Input.GetKey(jumpInput))
                    {
                        Jump();
                        playerState = PlayerStates.Jumping;
                    }

                    break;
                }
            case PlayerStates.Jumping:
                {
                    //rb.velocity -= Vector2.up * fallSpeedMultiplier;
                    //Head.GetComponent<Rigidbody2D>().velocity -= Vector2.up * 0.75f;
                    Jumping = true;
                    

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

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (playerState == PlayerStates.Running && collision.gameObject.CompareTag("Ground"))
            playerState = PlayerStates.Jumping;
    }

    void Jump()
    {
        rb.velocity = Vector2.up * jumpAmplitude;
        //Head.GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpAmplitude;
    }

}
