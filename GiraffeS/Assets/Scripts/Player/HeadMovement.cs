using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadMovement : MonoBehaviour
{
    public GameObject Body;
    public GameObject Head;
    public GameObject Neck;

    Vector3 mouseStart;
    Vector3 headStart;
    Vector3 bodyStart;

    
    //SkinnedMeshRenderer spriteR;
    SpriteRenderer spriteR;
    [SerializeField] Sprite neck5;
    [SerializeField] Sprite neck4;
    [SerializeField] Sprite neck3;
    [SerializeField] Sprite neck2;
    [SerializeField] Sprite neck1;


    float headToBodyStart;
    float headToBody;

    private void Start()
    {
        mouseStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseStart.x = 0;
        mouseStart.z = 0;
        headStart = Head.transform.position;
        bodyStart = Body.transform.position;
        headToBodyStart = headStart.y - bodyStart.y;

        spriteR = Neck.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        headToBody = Head.transform.position.y - Body.transform.position.y;

        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        mousePos.x = 0;
        //Head.transform.position = new Vector2(Head.transform.position.x, Input.mousePosition.y);
        Head.transform.position = headStart - (mouseStart - mousePos);

        if (Body.GetComponent<PlayerController>().Jumping == true)
        {
            Head.transform.position = (headStart + (Body.transform.position - bodyStart)) - (mouseStart - mousePos);
        }

        if (Head.transform.position.y > 4.0f)
        {
            Head.transform.position = new Vector3(headStart.x, 4.0f, 0.0f);
            //mouseStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseStart.y = mouseStart.y + headToBodyStart * 0.0171f;
            //Debug.Log(mouseStart.y);
        }
        if (Head.transform.position.y < Body.transform.position.y + 2)
        {
            Head.transform.position = new Vector3(headStart.x, Body.transform.position.y + 2, 0.0f);
            mouseStart.y = mouseStart.y - headToBodyStart * 0.0162f;
            //Debug.Log(mouseStart.y);
            //mouseStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        }

        Debug.Log(headToBody);

        if (headToBody >= 5)
        {
            spriteR.sprite = neck5;
            Debug.Log("neck5");
        }
        else if (headToBody < 5 && headToBody >= 4)
        {
            spriteR.sprite = neck4;
            Debug.Log("neck4");
        }
        else if (headToBody < 4 && headToBody >= 3)
        {
            spriteR.sprite = neck3;
            Debug.Log("neck3");
        }
        else if (headToBody < 3 && headToBody >= 2.5f)
        {
            spriteR.sprite = neck2;
            Debug.Log("neck2");
        }
        else if (headToBody < 2.5f && headToBody > 2) 
        {
            spriteR.sprite = neck1;
            Debug.Log("neck1");
        }



            Vector3 headPos = Head.transform.position;
        Vector3 bodyPos = Body.transform.position;


        Vector3 centerPos = new Vector3(headPos.x + bodyPos.x + 1.0f, headPos.y + bodyPos.y + 0.2f) / 2;

        float scaleX = Mathf.Abs(bodyPos.x - headPos.x);
        float scaleY = Mathf.Abs(bodyPos.y - headPos.y);

        Neck.transform.position = centerPos;
        Neck.transform.localScale = new Vector3(scaleX/1.5f, scaleY/3.3f, 1);
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
