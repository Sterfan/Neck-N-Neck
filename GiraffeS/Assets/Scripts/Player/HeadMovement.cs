using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadMovement : MonoBehaviour
{
    public GameObject Body;
    public GameObject Head;
    public GameObject Neck;

    public Vector3 mouseStart;
    public Vector3 headStart;
    public Vector3 bodyStart;

    public float headToBody;

    private void Start()
    {
        mouseStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseStart.x = 0;
        mouseStart.z = 0;
        headStart = Head.transform.position;
        bodyStart = Body.transform.position;
        headToBody = headStart.y - bodyStart.y;
    }

    void Update()
    {
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
            mouseStart.y = mouseStart.y + headToBody * 0.0171f;
            //Debug.Log(mouseStart.y);
        }
        if (Head.transform.position.y < Body.transform.position.y)
        {
            Head.transform.position = new Vector3(headStart.x, Body.transform.position.y, 0.0f);
            mouseStart.y = mouseStart.y - headToBody * 0.0162f;
            //Debug.Log(mouseStart.y);
            //mouseStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        }

        Vector3 headPos = Head.transform.position;
        Vector3 bodyPos = Body.transform.position;
        

        Vector3 centerPos = new Vector3(headPos.x + bodyPos.x, headPos.y + bodyPos.y) / 2;

        float scaleX = Mathf.Abs(bodyPos.x - headPos.x);
        float scaleY = Mathf.Abs(bodyPos.y - headPos.y);

        Neck.transform.position = centerPos;
        Neck.transform.localScale = new Vector3(scaleX/15, scaleY/4, 1);
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
