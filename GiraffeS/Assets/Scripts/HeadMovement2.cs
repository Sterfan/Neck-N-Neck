﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadMovement2 : MonoBehaviour
{
    public GameObject Body;
    public GameObject Head;
    public GameObject Neck;

    void Update()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        //mousePos.x = -3;
        Vector3 headMove = new Vector3(5.5f, mousePos.x, 0.0f);

        //Head.transform.position = new Vector2(Head.transform.position.x, Input.mousePosition.y);
        Head.transform.position = headMove;

        Vector3 headPos = Head.transform.position;
        Vector3 bodyPos = Body.transform.position;


        Vector3 centerPos = new Vector3(headPos.x + bodyPos.x, headPos.y + bodyPos.y) / 2;

        float scaleX = Mathf.Abs(bodyPos.x - headPos.x);
        float scaleY = Mathf.Abs(bodyPos.y - headPos.y);

        Neck.transform.position = centerPos;
        Neck.transform.localScale = new Vector3(scaleX / 15, scaleY / 4, 1);
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
