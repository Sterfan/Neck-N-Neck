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

    public float xHeadOffset = 0.7f;
    float headToBodyStart;
    float headToBody;
    float maxNeckLength = 7.0f;
    [SerializeField] float minNeckLength = 1.95f;
    float yMouse;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;

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

        headToBody = Head.transform.position.y - Body.transform.position.y;

        if (Input.GetMouseButton(0) && Input.mousePosition.x <= Screen.width / 2.0f) 
        {
            yMouse = Input.GetAxis("Mouse Y");
            mouseMovement = new Vector2(0.0f, yMouse);
            mouseInput = new Vector3(0, yMouse, 0);

            Head.transform.position += mouseInput * mouseSensitivity;
            //Debug.Log("width: "+ Screen.width);
        }


        if (headToBody > maxNeckLength)
        {
            Head.transform.position = new Vector2(Head.transform.position.x, bodyPos.y + maxNeckLength);
        }

        else if (Head.transform.position.y <= Body.transform.position.y + minNeckLength)
        {
            Head.transform.position = new Vector2(Head.transform.position.x, Body.transform.position.y + minNeckLength);
        }

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
            spriteR.sprite = neck4;
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
}