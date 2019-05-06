using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public enum PlayerStates
    {
        Jumping,
        Running,
        Dashing,
    };

    PlayerStates playerState = PlayerStates.Jumping;

    public GameObject background;

    public float jumpAmplitude = 15.0f;
    float dashSpeed = 3.0f;
    float dashDuration = 0.5f;
    float deceleration;
    [SerializeField] float dashAmmo;
    //Doesn't work when it's a variable idk why, go change value manually
    //public float fallSpeedMultiplier = 0.75f;
    public KeyCode jumpInput = KeyCode.Space;
    public KeyCode dashInput = KeyCode.D;
    //public GameObject Head;
    public bool Jumping = false;
    public bool Dashing = false;
    public bool testPurposes;

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (testPurposes)
        {
            Debug.Log(playerState);
        }
        switch (playerState)
        {
            case PlayerStates.Running:
                {
                    animator.SetBool("IsRunning", true);
                    Jumping = false;
                    if (Input.GetKeyUp(jumpInput))
                    {
                        Jump();
                        playerState = PlayerStates.Jumping;
                        animator.SetBool("IsJumping", true);
                    }
                    if (Input.GetKey(dashInput) && dashAmmo > 0.0f)
                    {
                        Dash(dashSpeed);
                        playerState = PlayerStates.Dashing;
                        Dashing = true;
                        dashAmmo -= 1.0f;
                        if (dashAmmo < 0.0f)
                        {
                            dashAmmo = 0.0f;
                        }
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
                    
                    if (background.GetComponent<BGSpeedMultiplier>().GetSpeedMultiplier() <= 1.0f)
                    {
                        playerState = PlayerStates.Running;
                        Dashing = false;
                    }

                    break;
                }

        }
    }

    


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (playerState == PlayerStates.Jumping && collision.gameObject.CompareTag("Ground"))
        {
            playerState = PlayerStates.Running;
            animator.SetBool("IsJumping", false);
        }
    }

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (playerState == PlayerStates.Running && collision.gameObject.CompareTag("Ground"))
    //        playerState = PlayerStates.Jumping;
    //}

    void Jump()
    {
        rb.velocity = Vector2.up * jumpAmplitude;
        //Head.GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpAmplitude;
    }

    void Dash(float dashSpeed)
    {
        background.GetComponent<BGSpeedMultiplier>().SetSpeedMultiplier(dashSpeed);
        Invoke("ResetSpeed", dashDuration);
    }

    void ResetSpeed()
    {
        background.GetComponent<BGSpeedMultiplier>().SetSpeedMultiplier(1.0f);
        playerState = PlayerStates.Running;
    }

    public void SetDashAmmo(float ammo)
    {
        dashAmmo += ammo;
    }
}
