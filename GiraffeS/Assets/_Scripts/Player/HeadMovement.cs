using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadMovement : MonoBehaviour
{
    public GameObject Body;
    public GameObject Head;
    public GameObject Neck;
    public GameObject Giraffe;

    Vector2 mouseStart;
    Vector2 headStart;
    Vector2 bodyStart;

    
    //SkinnedMeshRenderer spriteR;
    SpriteRenderer spriteR;
    public Sprite neck7;
    public Sprite neck6;
    public Sprite neck5;
    public Sprite neck4;
    public Sprite neck3;
    public Sprite neck2;
    public Sprite neck1;

    [SerializeField] float mouseSlower = 1.0f;

    public bool xGiraffe;
    public bool yGiraffe;

    float headToBodyStart;
    float headToBody;
    float maxNeckLength = 6.5f;
    float minNeckLength;

    private void Start()
    {
        Cursor.visible = false;
        mouseStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (yGiraffe == true)
        {
            xGiraffe = false;

        }
        if (xGiraffe == true)
        {
            yGiraffe = false;
            mouseStart.y = mouseStart.x;
        }

        mouseStart.x = 0;
        //mouseStart.z = 0;
        headStart = Head.transform.position;
        bodyStart = Body.transform.position;
        headToBodyStart = headStart.y - bodyStart.y;

        spriteR = Neck.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        headToBody = Head.transform.position.y - Body.transform.position.y;
        //Debug.Log(headToBody);
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 headPos = Head.transform.position;
        Vector2 bodyPos = Body.transform.position;
        minNeckLength = Body.transform.position.y + 2;

        //mousePos.z = 0;



        if (yGiraffe == true)
        {
            //Debug.Log(Head.transform.position.y - minNeckLength);
            mousePos.x = 0;
            //Head.transform.position = new Vector2(Head.transform.position.x, Input.mousePosition.y);
            Head.transform.position = new Vector2(Head.transform.position.x, headStart.y) - ((mouseStart - mousePos) / mouseSlower);
   
            if (Giraffe.GetComponent<PlayerController>().Jumping == true && Head.transform.position.y <= bodyStart.y + maxNeckLength)
            {
                Head.transform.position = (new Vector2(Head.transform.position.x, headStart.y) + (bodyPos - bodyStart)) - ((mouseStart - mousePos) / mouseSlower);
            }

            if (Head.transform.position.y > bodyStart.y + maxNeckLength)
            {
                //Head.transform.position = new Vector2(headStart.x, bodyPos.y + maxNeckLength);
                Head.transform.position = new Vector2(Head.transform.position.x, bodyPos.y + maxNeckLength);

                //mouseStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mouseStart.y = mouseStart.y + headToBodyStart * 0.035f;
            }

            if (Head.transform.position.y < minNeckLength)
            {
                //Head.transform.position = new Vector2(headStart.x, minNeckLength);
                Head.transform.position = new Vector2(Head.transform.position.x, minNeckLength);

                mouseStart.y = mouseStart.y - headToBodyStart * 0.039f;
                //mouseStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            }

        }

        if (xGiraffe == true)
        {
            mousePos.y = 0;
            Vector2 headMove = new Vector2(0.0f, mousePos.x);

            Head.transform.position = headStart - ((mouseStart - headMove) / mouseSlower);

            if (Giraffe.GetComponent<PlayerController>().Jumping == true && Head.transform.position.y <= bodyStart.y + maxNeckLength)
            {
                Head.transform.position = (headStart + (bodyPos - bodyStart)) - ((mouseStart - headMove) / mouseSlower);
            }

            if (Head.transform.position.y > bodyStart.y + maxNeckLength)
            {
                //Head.transform.position = new Vector2(headStart.x, bodyPos.y + maxNeckLength);
                Head.transform.position = new Vector2(Head.transform.position.x, bodyPos.y + maxNeckLength);

                mouseStart.y = mouseStart.y + headToBody * 0.042f;

            }
            if (Head.transform.position.y < minNeckLength)
            {
                //Head.transform.position = new Vector2(headStart.x, minNeckLength);
                Head.transform.position = new Vector2(Head.transform.position.x, minNeckLength);

                mouseStart.y = mouseStart.y - headToBody * 0.039f;
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






        Vector2 centerPos = new Vector2(headPos.x + bodyPos.x + 0.7f, headPos.y + bodyPos.y + 0.3f) / 2;

        float scaleX = Mathf.Abs(bodyPos.x - headPos.x);
        float scaleY = Mathf.Abs(bodyPos.y - headPos.y);

        Neck.transform.position = centerPos;
        Neck.transform.localScale = new Vector3(scaleX/1.0f, scaleY/3.3f, 1);
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
