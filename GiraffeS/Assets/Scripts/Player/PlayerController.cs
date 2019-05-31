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
    public GameObject DashFlames;
    public GameObject HeadSpeedParticles;
    public GameObject BodySpeedParticles;
    public GameObject TearParticles;
    public GameObject Head;

    public Sprite NormalHead;
    public Sprite DashHead;

    public GameObject dustParticleSystem;


    SpriteRenderer spriteRenderer;


    [SerializeField] float jumpAmplitude = 15.0f;
    [SerializeField] float dashSpeed = 14.0f;
    [SerializeField] float baseSpeed = 7.0f;
    float currentDashSpeed;
    [SerializeField] float dashDuration = 0.5f;
    float dashTimer = 0.0f;
    float deceleration = 0.976f;
    [SerializeField] float dashAmmo;
    //Doesn't work when it's a variable idk why, go change value manually
    //public float fallSpeedMultiplier = 0.75f;
    public KeyCode jumpInput = KeyCode.Space;
    public KeyCode dashInput = KeyCode.D;
    //public GameObject Head;
    public bool Jumping = false;
    public bool Dashing = false;
    public bool testPurposes;
    bool startGame = false;

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        spriteRenderer = Head.GetComponent<SpriteRenderer>();
        currentDashSpeed = dashSpeed;
    }

    void FixedUpdate()
    {

        if (testPurposes)
        {
            //Debug.Log(playerState);
        }
        switch (playerState)
        {
            case PlayerStates.Running:
                {
                    if (startGame)
                    {
                        if (dustParticleSystem)
                            dustParticleSystem.SetActive(true);
                    }

                    
                    animator.SetBool("IsRunning", true);
                    Jumping = false;
                    if (Input.GetKey(jumpInput) && startGame == true)
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
                    if (dustParticleSystem)
                        dustParticleSystem.SetActive(false);

                    Jumping = true;
                    animator.SetBool("IsJumping", true);

                    //if (dashAmmo >= 1.0f)
                    //{
                    //    Dash(dashSpeed);
                    //    playerState = PlayerStates.Dashing;
                    //    Dashing = true;
                    //    dashAmmo -= 1.0f;
                    //    if (dashAmmo < 0.0f)
                    //    {
                    //        dashAmmo = 0.0f;
                    //    }
                    //}

                    break;
                } 
            case PlayerStates.Dashing:
                {
                    if (dustParticleSystem)
                        dustParticleSystem.SetActive(true);
                    DashFlames.SetActive(true);
                    //animator.SetBool("IsDashing", true);
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
                            Physics2D.IgnoreLayerCollision(14, 16, false);
                            playerState = PlayerStates.Running;
                            Dashing = false;
                        }
                    }

                    if (Input.GetKey(jumpInput))
                    {
                        Jump();
                    }


                    break;
                }

        }
    }

    


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (playerState == PlayerStates.Jumping && collision.gameObject.CompareTag("Ground"))
        {
            FindObjectOfType<AudioManager>().Play("GiraffeLand");
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
        FindObjectOfType<AudioManager>().Play("GiraffeJump");
        //Head.GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpAmplitude;
    }

    public void Dash(float dashSpeed)
    {
        //Backgrounds.GetComponent<BGSpeedMultiplier>().SetSpeedMultiplier(dashSpeed);
        FindObjectOfType<AudioManager>().Play("GiraffeDash");
        spriteRenderer.sprite = DashHead;
        SpeedController.GetComponent<MainSpeed>().SetSpeed(dashSpeed);
        Physics2D.IgnoreLayerCollision(11, 14, true);
        Physics2D.IgnoreLayerCollision(12, 13, true);
        GetComponent<CollisionLogic>().SetSpeedUpFalse();
        Backgrounds.GetComponent<BGSpeedMultiplier>().SetSpeedMultiplier(1.0f);
        //Debug.Log("SPEED MULITPLIER AT DASH = " + Backgrounds.GetComponent<BGSpeedMultiplier>().GetSpeedMultiplier());
        SetSpeedParticlesActive(true);
        TearParticles.GetComponent<ParticleSystem>().Play();
        Physics2D.IgnoreLayerCollision(14, 16, true);

        //playerState = PlayerStates.Dashing;

        //Invoke("ResetSpeed", dashDuration);
    }

    void ResetSpeed()
    {
        //Backgrounds.GetComponent<BGSpeedMultiplier>().SetSpeedMultiplier(1.0f);
        spriteRenderer.sprite = NormalHead;
        SpeedController.GetComponent<MainSpeed>().SetSpeed(baseSpeed);
        Physics2D.IgnoreLayerCollision(11, 14, false);
        Physics2D.IgnoreLayerCollision(12, 13, false);
        DashFlames.SetActive(false);
        SetSpeedParticlesActive(false);
        TearParticles.GetComponent<ParticleSystem>().Stop();
        //gameObject.GetComponent<CollisionLogic>().SetSpeedUpFalse();
    }

    public void SetDashAmmo(float ammo)
    {
        dashAmmo += ammo;
    }

    public void SetSpeedParticlesActive(bool active)
    {
        if (active == true)
        {
            HeadSpeedParticles.GetComponent<ParticleSystem>().Play();
            BodySpeedParticles.GetComponent<ParticleSystem>().Play();
        }
        else
        {
            HeadSpeedParticles.GetComponent<ParticleSystem>().Stop();
            BodySpeedParticles.GetComponent<ParticleSystem>().Stop();
        }
    }

    public PlayerStates GetPlayerState()
    {
        return playerState;
    }

    public void StartGame()
    {
        startGame = true;
    }
}
