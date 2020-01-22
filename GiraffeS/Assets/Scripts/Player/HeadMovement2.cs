using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadMovement2 : MonoBehaviour
{
    public GameObject Body;
    public GameObject Head;
    public GameObject Neck;
    public GameObject Giraffe;

    Vector2 headStart;
    Vector2 bodyStart;

    Vector2 mouseMovement;

    Vector3 mouseInput;

    SpriteRenderer spriteR;
    public Sprite neck7;
    public Sprite neck6;
    public Sprite neck5;
    public Sprite neck4;
    public Sprite neck3;
    public Sprite neck2;
    public Sprite neck1;

    [SerializeField] float mouseSensitivity = 0.05f;

    public bool xGiraffe;
    public bool yGiraffe;

    public float xHeadOffset = 0.7f;
    float headToBodyStart;
    float headToBody;
    float maxNeckLength = 7.0f;
    [SerializeField] float minNeckLength = 1.9f;
    float yMouse;
    float xMouse;

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

        Head.transform.position = new Vector2(Head.transform.position.x, Body.transform.position.y + minNeckLength);
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
            //Debug.Log(Input.GetAxis("Mouse Y"));
            yMouse = Input.GetAxis("Mouse Y");
            mouseMovement = new Vector2(0.0f, yMouse);
            mouseInput = new Vector3(0, yMouse, 0);

            //Head.transform.position = new Vector2(Head.transform.position.x, Input.mousePosition.y);
            Head.transform.position -= mouseInput * mouseSensitivity;

            //if (Body.GetComponent<PlayerController>().Jumping == true)
            //{
            //    //Head.transform.position = (headStart + (Body.transform.position - bodyStart)) - ((mouseStart - mousePos) / mouseSlower);
            //    Head.transform.position = (headPos + (bodyPos - bodyStart)) + (mouseMovement * mouseSensitivity);

            //}

            if (headToBody > maxNeckLength)
            {
                Head.transform.position = new Vector2(Head.transform.position.x, bodyPos.y + maxNeckLength);
                //mouseStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                //mouseStart.y = mouseStart.y + headToBodyStart * 0.042f;
            }
            if (Head.transform.position.y <= Body.transform.position.y + minNeckLength)
            {
                Head.transform.position = new Vector2(Head.transform.position.x, Body.transform.position.y + minNeckLength);
                //mouseStart.y = mouseStart.y - headToBodyStart * 0.039f;
                //mouseStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            }

        }

        if (xGiraffe == true)
        {
            xMouse = Input.GetAxis("Mouse X");
            mouseMovement = new Vector2(0.0f, xMouse);
            mouseInput = new Vector3(0, xMouse, 0);



            //Vector3 headMove = new Vector3(0.0f, mousePos.x, 0.0f);

            //Head.transform.position = headStart - ((mouseStart - headMove) / mouseSlower);
            //Head.transform.position += new Vector3(Head.transform.position.x, xMouse, 0);
            Head.transform.position -= mouseInput * mouseSensitivity;


            //if (Giraffe.GetComponent<PlayerController>().Jumping == true)
            //{
            //    //Head.transform.position = (headStart + (Body.transform.position - bodyStart)) - ((mouseStart - headMove) / mouseSlower);
            //    //Head.transform.position = (headPos + (bodyPos - bodyStart)) + (mouseMovement * mouseSensitivity);
            //}

            if (headToBody > maxNeckLength)
            {
                Head.transform.position = new Vector2(Head.transform.position.x, bodyPos.y + maxNeckLength);
                //mouseStart.y = mouseStart.y + headToBody * 0.042f;

            }
            if (Head.transform.position.y <= Body.transform.position.y + minNeckLength)
            {
                Head.transform.position = new Vector2(Head.transform.position.x, Body.transform.position.y + minNeckLength);
                //mouseStart.y = mouseStart.y - headToBody * 0.039f;
            }
        }

        //Debug.Log(headToBody);
        Vector3 centerPos = new Vector3(headPos.x + bodyPos.x + xHeadOffset, headPos.y + bodyPos.y + 0.4f) / 2;
        float scaleX = Mathf.Abs(bodyPos.x - headPos.x);
        float scaleY = Mathf.Abs(bodyPos.y - headPos.y);

        if (headToBody >= 6)
        {
            spriteR.sprite = neck7;
            Neck.transform.localScale = new Vector3(scaleX / 2.5f, scaleY / 3.6f, 1);
            //Debug.Log("neck5");
        }
        else if (headToBody < 6 && headToBody >= 4.5f)
        {
            spriteR.sprite = neck6;
            Neck.transform.localScale = new Vector3(scaleX / 2.5f, scaleY / 3.6f, 1);
        }
        else if (headToBody < 4.5f && headToBody >= 3.75f)
        {
            spriteR.sprite = neck5;
            Neck.transform.localScale = new Vector3(scaleX / 2.5f, scaleY / 3.6f, 1);
        }
        else if (headToBody < 3.75f && headToBody >= 3)
        {
            spriteR.sprite = neck4; //HAPPENS TOO SOON FROM HERE ON
            Neck.transform.localScale = new Vector3(scaleX / 2.5f, scaleY / 3.6f, 1);
            //Debug.Log("neck4");
        }
        else if (headToBody < 3 && headToBody >= 2.5f)
        {
            spriteR.sprite = neck3;
            Neck.transform.localScale = new Vector3(scaleX / 2.5f, scaleY / 3.4f, 1);
            //Debug.Log("neck3");
        }
        else if (headToBody < 2.5f && headToBody >= 2.25f)
        {
            spriteR.sprite = neck2;
            Neck.transform.localScale = new Vector3(scaleX / 2.5f, scaleY / 2.9f, 1);
            //Debug.Log("neck2");
        }
        else if (headToBody < 2.25f && headToBody > minNeckLength)
        {
            spriteR.sprite = neck1;
            Neck.transform.localScale = new Vector3(scaleX / 2.5f, scaleY / 2.5f, 1);
            //Debug.Log("neck1");
        }








        Neck.transform.position = centerPos;
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