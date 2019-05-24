using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public float mainTimer;
    public GameObject three;
    public GameObject two;
    public GameObject one;
    public GameObject go;
    //public TMPro.TextMeshProUGUI text;

    public bool startGame = false;

    private float timer;
    private bool canCount = true;
    private bool doOnce = false;

    private void Awake()
    {
        Cursor.visible = false;
    }

    private void Start()
    {
        timer = mainTimer;
    }

    private void Update()
    {
        //Debug.Log(startGame);
        if (timer >= 0.0f && canCount)
        {
            timer -= Time.deltaTime;
            if (timer <= 3.0f && timer > 2.0f)
            {
                //text.text = "3";
                three.SetActive(true);
            }
            if (timer > 1.0f && timer <= 2.0f)
            {
                //three.GetComponent<TMPro.TextMeshProUGUI>().color = new Color(0, 0, 0, 0);
                three.SetActive(false);
                two.SetActive(true);

            }
            if (timer > 0.0f && timer <= 1.0f)
            {
                //two.GetComponent<TMPro.TextMeshProUGUI>().color = new Color(0, 0, 0, 0);
                two.SetActive(false);
                one.SetActive(true);

            }
        }
        else if (timer <= 0.0f && !doOnce)
        {
            //Debug.Log("Should be true");
            startGame = true;
            //one.GetComponent<TMPro.TextMeshProUGUI>().color = new Color(0, 0, 0, 0);
            one.SetActive(false);
            go.SetActive(true);
            Invoke("SetGoFalse", 0.5f);
            canCount = false;
            doOnce = true;
            timer = 0.0f;
            FindObjectOfType<AudioManager>().Play("GiraffeWalk");
        }
    }

    void SetGoFalse()
    {
        //go.GetComponent<TMPro.TextMeshProUGUI>().color = new Color(0, 0, 0, 0);
        go.SetActive(false);
    }

    public bool GetStartGame()
    {
        return startGame;
    }
}
