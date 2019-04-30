using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadMovement2 : MonoBehaviour
{
    public GameObject Body;
    public GameObject Head;
    public GameObject Neck;

    Vector2 headStart;
    Vector2 bodyStart;

    Vector2 mouseMovement;

    SpriteRenderer spriteR;
    public Sprite neck7;
    public Sprite neck6;
    public Sprite neck5;
    public Sprite neck4;
    public Sprite neck3;
    public Sprite neck2;
    public Sprite neck1;

    [SerializeField] int mouseSlower = 3;

    public bool xGiraffe;
    public bool yGiraffe;

    float headToBodyStart;
    float headToBody;
    float maxNeckLength = 7.0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        if (yGiraffe == true)
        {
            xGiraffe = false;

        }
        if (xGiraffe == true)
        {
            yGiraffe = false;
        }

        Head.transform.position = new Vector2(Head.transform.position.x, Body.transform.position.y + 2);
        headStart = Head.transform.position;
        bodyStart = Body.transform.position;
        headToBodyStart = headStart.y - bodyStart.y;

        spriteR = Neck.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector2 headPos = Head.transform.position;
        Vector2 bodyPos = Body.transform.position;

        //mouseMovement = new Vector2(0.0f, Input.GetAxis("Mouse X"));
        headToBody = Head.transform.position.y - Body.transform.position.y;
        //var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //mousePos.z = 0;

        if (yGiraffe == true)
        {
            mouseMovement = new Vector2(0.0f, Input.GetAxis("Mouse Y"));

            //Head.transform.position = new Vector2(Head.transform.position.x, Input.mousePosition.y);
            headPos += mouseMovement;

            if (Body.GetComponent<PlayerController>().Jumping == true)
            {
                //Head.transform.position = (headStart + (Body.transform.position - bodyStart)) - ((mouseStart - mousePos) / mouseSlower);
                Head.transform.position = (headPos + (bodyPos - bodyStart)) + (mouseMovement * mouseSlower);

            }

            if (headToBody > maxNeckLength)
            {
                Head.transform.position = new Vector2(headStart.x, bodyPos.y + maxNeckLength);
                //mouseStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                //mouseStart.y = mouseStart.y + headToBodyStart * 0.042f;
            }
            if (Head.transform.position.y <= Body.transform.position.y + 2)
            {
                Head.transform.position = new Vector2(headStart.x, Body.transform.position.y + 2);
                //mouseStart.y = mouseStart.y - headToBodyStart * 0.039f;
                //mouseStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            }

        }

        if (xGiraffe == true)
        {
            mouseMovement = new Vector2(0.0f, Input.GetAxis("Mouse X"));

            //Vector3 headMove = new Vector3(0.0f, mousePos.x, 0.0f);

            //Head.transform.position = headStart - ((mouseStart - headMove) / mouseSlower);
            headPos += mouseMovement;

            if (Body.GetComponent<PlayerController>().Jumping == true)
            {
                //Head.transform.position = (headStart + (Body.transform.position - bodyStart)) - ((mouseStart - headMove) / mouseSlower);
                Head.transform.position = (headPos + (bodyPos - bodyStart)) + (mouseMovement * mouseSlower);
            }

            if (headToBody > maxNeckLength)
            {
                Head.transform.position = new Vector2(headStart.x, bodyPos.y + maxNeckLength);
                //mouseStart.y = mouseStart.y + headToBody * 0.042f;

            }
            if (Head.transform.position.y <= Body.transform.position.y + 2)
            {
                Head.transform.position = new Vector2(headStart.x, Body.transform.position.y + 2);
                //mouseStart.y = mouseStart.y - headToBody * 0.039f;
            }
        }

        //Debug.Log(headToBody);

        if (headToBody >= 6)
        {
            spriteR.sprite = neck7;
            //Debug.Log("neck5");
        }
        else if (headToBody < 6 && headToBody >= 4.5f)
        {
            spriteR.sprite = neck6;
        }
        else if (headToBody < 4.5f && headToBody >= 3.75f)
        {
            spriteR.sprite = neck5;
        }
        else if (headToBody < 3.75f && headToBody >= 3)
        {
            spriteR.sprite = neck4; //HAPPENS TOO SOON FROM HERE ON
            //Debug.Log("neck4");
        }
        else if (headToBody < 3 && headToBody >= 2.5f)
        {
            spriteR.sprite = neck3;
            //Debug.Log("neck3");
        }
        else if (headToBody < 2.5f && headToBody >= 2.25f)
        {
            spriteR.sprite = neck2;
            //Debug.Log("neck2");
        }
        else if (headToBody < 2.25f && headToBody > 2)
        {
            spriteR.sprite = neck1;
            //Debug.Log("neck1");
        }






        Vector3 centerPos = new Vector3(headPos.x + bodyPos.x + 0.7f, headPos.y + bodyPos.y + 0.4f) / 2;

        float scaleX = Mathf.Abs(bodyPos.x - headPos.x);
        float scaleY = Mathf.Abs(bodyPos.y - headPos.y);

        Neck.transform.position = centerPos;
        Neck.transform.localScale = new Vector3(scaleX / 1.0f, scaleY / 3.7f, 1);
    }

    //    void NeckDraw(Vector3 headPos, Vector3 bodyPos)
    //    {
    //        Vector3 centerPos = new Vector3(headPos.x + bodyPos.x, headPos.y + bodyPos.y) / 2;

    //        float scaleX = Mathf.Abs(bodyPos.x - headPos.x);
    //        float scaleY = Mathf.Abs(bodyPos.y - headPos.y);

    //        Neck.transform.position = centerPos;
    //        Neck.transform.localScale = new Vector3(scaleX, scaleY, 1);
    //    }
}