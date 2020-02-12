using UnityEngine;

public class CollisionLogic : MonoBehaviour
{
    public GameObject Backgrounds;
    public GameObject Giraffe;
    public GameObject LeafParticles;
    public GameObject ThornParticles;
    public GameObject CountdownTimer;
    public GameObject ProgressTracker;
    public GameObject HeadSpeedLines1;
    public GameObject BodySpeedLines1;
    public GameObject HeadSpeedLines2;
    public GameObject BodySpeedLines2;
    public GameObject HeadSpeedLines3;
    public GameObject BodySpeedLines3;

    public Leaves leaves;
    public Leaves spikes;
    
    bool inBush = false;
    bool inSpikes = false;
    bool shouldSpeedUp = false;
    float scrollSpeed;
    float multiplier;
    float timeSinceHit = 0.0f;
    float overSpeedAcceleration = 0.1f;
    [SerializeField] float acceleration = 0.15f;


    private void Start()
    {
        multiplier = Backgrounds.GetComponent<BGSpeedMultiplier>().GetSpeedMultiplier();
    }

    private void Update()
    {
        if (CountdownTimer.GetComponent<CountdownTimer>().GetStartGame() == true && ProgressTracker.GetComponent<PlayerProgress>().isFinished == false)
        {
            timeSinceHit += Time.deltaTime;
            if (timeSinceHit >= 6.0f && multiplier <= 1.3f)
            {
                multiplier += overSpeedAcceleration * Time.deltaTime;
                Backgrounds.GetComponent<BGSpeedMultiplier>().SetSpeedMultiplier(multiplier);
                HeadSpeedLines1.SetActive(true);
                BodySpeedLines1.SetActive(true);
                if (multiplier >= 1.13f)
                {
                    HeadSpeedLines2.SetActive(true);
                    BodySpeedLines2.SetActive(true);
                    if (multiplier > 1.15f)
                    {
                        HeadSpeedLines1.SetActive(false);
                        BodySpeedLines1.SetActive(false);
                    }
                }
                if (multiplier >= 1.23f)
                {
                    HeadSpeedLines3.SetActive(true);
                    BodySpeedLines3.SetActive(true);
                    if (multiplier > 1.25f)
                    {
                        HeadSpeedLines2.SetActive(false);
                        BodySpeedLines2.SetActive(false);
                    }
                }
            }
        }
        if (multiplier <= 1.0f)
        {
            HeadSpeedLines1.SetActive(false);
            BodySpeedLines1.SetActive(false);
            HeadSpeedLines2.SetActive(false);
            BodySpeedLines2.SetActive(false);
            HeadSpeedLines3.SetActive(false);
            BodySpeedLines3.SetActive(false);
        }

        if (shouldSpeedUp == true && multiplier <= 1.0f)
        {
            if (Giraffe.GetComponent<PlayerController>().GetPlayerState() != PlayerController.PlayerStates.Dashing)
            {
                multiplier += acceleration * Time.deltaTime;
                Backgrounds.GetComponent<BGSpeedMultiplier>().SetSpeedMultiplier(multiplier);
                if (multiplier >= 1.0f)
                {
                    shouldSpeedUp = false;
                    multiplier = 1.0f;
                }

            }
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("HeadObstacle") || collision.CompareTag("LegObstacle"))
        {
            shouldSpeedUp = false;
            if (collision.CompareTag("HeadObstacle") && LeafParticles.GetComponent<ParticleSystem>().isEmitting == false)
            {
                LeafParticles.GetComponent<ParticleSystem>().Play();
                inBush = true;
                if (leaves == null)
                    Debug.LogError(gameObject.name + (" is missing leaf reference."));
                else
                    leaves.StartShakyShaky();
            }
            if (collision.CompareTag("LegObstacle") && ThornParticles.GetComponent<ParticleSystem>().isEmitting == false)
            {
                ThornParticles.GetComponent<ParticleSystem>().Play();
                inSpikes = true;
                if (spikes == null)
                    Debug.LogError(gameObject.name + (" is missing spikes reference."));
                else
                    spikes.StartShakyShaky();
            }

            FindObjectOfType<AudioManager>().Play("Leaves");
            if (multiplier >= 0.7f)
            {
                multiplier = 0.7f;
                Backgrounds.GetComponent<BGSpeedMultiplier>().SetSpeedMultiplier(multiplier);
                timeSinceHit = 0.0f;

            }
        }
        if (collision.CompareTag("DashAmmo"))
        {
            Giraffe.GetComponent<PlayerController>().SetDashAmmo(1.0f);
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("HeadObstacle") || collision.CompareTag("LegObstacle"))
            shouldSpeedUp = false;
            timeSinceHit = 0.0f;
            if (multiplier >= 0.25f)
            {
                multiplier *= 0.98f;
                Backgrounds.GetComponent<BGSpeedMultiplier>().SetSpeedMultiplier(multiplier);
            }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("HeadObstacle") || collision.CompareTag("LegObstacle"))
        {
            timeSinceHit = 0.0f;
            shouldSpeedUp = true;
            FindObjectOfType<AudioManager>().StopMusic("Leaves");
            if (collision.CompareTag("HeadObstacle"))
            {
                LeafParticles.GetComponent<ParticleSystem>().Stop();
                inBush = false;
            }
            if (collision.CompareTag("LegObstacle"))
            {
                ThornParticles.GetComponent<ParticleSystem>().Stop();
                inSpikes = false;
            }
        }
    }

    public void SetSpeedUpFalse()
    {
        shouldSpeedUp = false;
    }

    public bool IsInBush { get { return inBush; } }
    public bool IsInSpikes { get { return inSpikes; } }

    public void StartSpeedLines(GameObject[] speedlines)
    {
        for (int i = 0; i < 2; i++)
        {
            speedlines[i].SetActive(true);
        }
    }

    public void StopSpeedLines(GameObject[] speedlines)
    {
        for (int i = 0; i < 2; i++)
        {
            speedlines[i].SetActive(false);
        }
    }
}
