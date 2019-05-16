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

    public int grffenumber;

    public GameObject Backgrounds;
    public GameObject SpeedController;

    [SerializeField] float jumpAmplitude = 15.0f;
    [SerializeField] float dashSpeed = 14.0f;
    [SerializeField] float baseSpeed = 7.0f;
    float currentDashSpeed;
    [SerializeField] float dashDuration = 0.5f;
    float dashTimer = 0.0f;
    float deceleration = 0.99f;
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

    private void Start()
    {
        currentDashSpeed = dashSpeed;
    }

    void Update()
    {

        if (testPurposes)
        {
            //Debug.Log(playerState);
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
                    }
                    //if (Input.GetKey(dashInput) && dashAmmo > 0.0f)
                    if (dashAmmo >= 1.0f)
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
                    animator.SetBool("IsJumping", true);



                    break;
                } 
            case PlayerStates.Dashing:
                {
                    Debug.Log("DashTimer" + dashTimer);
                    dashTimer += Time.deltaTime;
                    //Debug.Log(dashTimer);
                    if (dashTimer >= dashDuration)
                    {
                        currentDashSpeed *= deceleration;
                        //Debug.Log("currentDashSpeed = " + currentDashSpeed);
                        //Backgrounds.GetComponent<BGSpeedMultiplier>().SetSpeedMultiplier(currentDashSpeed);
                        SpeedController.GetComponent<MainSpeed>().SetSpeed(currentDashSpeed);

                        //if (Backgrounds.GetComponent<BGSpeedMultiplier>().GetSpeedMultiplier() <= 1.0f)
                        if (SpeedController.GetComponent<MainSpeed>().GetSpeed() <= baseSpeed)
                        {
                            ResetSpeed();
                            currentDashSpeed = dashSpeed;
                            dashTimer = 0.0f;
                            playerState = PlayerStates.Running;
                            Dashing = false;
                        }
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

    public void Dash(float dashSpeed)
    {
        //Backgrounds.GetComponent<BGSpeedMultiplier>().SetSpeedMultiplier(dashSpeed);
        SpeedController.GetComponent<MainSpeed>().SetSpeed(dashSpeed);
        //playerState = PlayerStates.Dashing;

        //Invoke("ResetSpeed", dashDuration);
    }

    void ResetSpeed()
    {
        //Backgrounds.GetComponent<BGSpeedMultiplier>().SetSpeedMultiplier(1.0f);
        SpeedController.GetComponent<MainSpeed>().SetSpeed(baseSpeed);
    }

    public void SetDashAmmo(float ammo)
    {
        dashAmmo += ammo;
    }
}
