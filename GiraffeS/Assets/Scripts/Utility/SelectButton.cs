using UnityEngine;
using System.Collections.Generic;

public class SelectButton : MonoBehaviour/*, ISelectHandler, IDeselectHandler*/
{
    [SerializeField]
    GameObject giraffeHead;

    [SerializeField]
    pButton button;

    [SerializeField]
    GameObject leaf;

    public static List<pButton> buttons = new List<pButton>();

    //public static HashSet<pButton> allButtons = new HashSet<pButton>();
    //public static HashSet<pButton> currentButtons = new HashSet<pButton>();

    //public GameObject counterpart;
    //[HideInInspector]
    //public bool counterpartSelected = false;

    //private void Awake()
    //{
    //    //allButtons.Add(this.GetComponentInParent<pButton>());

    //}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == giraffeHead)
        {
            if (Input.GetKeyDown(KeyCode.W) && collision.GetComponent<HeadMovement2>().xGiraffe)
            {
                //Debug.Log("W was pressed when graffe was in the collider");
                InvokeSelection(1);
            }
            if (Input.GetKeyDown(KeyCode.Space) && collision.GetComponent<HeadMovement2>().yGiraffe)
            {
                //Debug.Log("Space was pressed when graffe was in the collider");
                InvokeSelection(2);
            }
        }
    }

    public void InvokeSelection(int grff)
    {
        Deselect(grff);

        button.Selected(grff);
        leaf.SetActive(true);
    }

    public void Deselect(int grff)
    {
        foreach (var button in buttons)
        {
            //Debug.Log(grff);
            //leaf.SetActive(false);
            button.Deselected(grff);
        }
    }

    //public void DeactivateLeaf()
    //{
    //    //Debug.Log("Leaf is " + leaf.activeSelf);
    //    leaf.SetActive(false);
    //}



    //public void Click(bool grffe1)
    //{
    //    if (grffe1)
    //    {
    //        button.onClick.Invoke();
    //    }
    //}

    //public void NextScene()
    //{
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    //}




    //public void OnSelect(BaseEventData eventData)
    //{
    //    DeselectAll(eventData);
    //    currentButtons.Add(this.GetComponentInParent<pButton>());
    //    //here I leave the leaf (like sprite change if it were one button)
    //    Debug.Log("ok?");
    //    transform.parent.transform.Find("Right Leaf").gameObject.SetActive(true);
    //}

    //public void OnDeselect(BaseEventData eventData)
    //{
    //    //here I take off the leaf
    //    Debug.Log("ok!");
    //    transform.parent.transform.Find("Right Leaf").gameObject.SetActive(false);
    //}

    //public static void DeselectAll(BaseEventData eventData)
    //{
    //    foreach(pButton selectable in currentButtons)
    //    {
    //        selectable.OnDeselect(eventData);
    //        currentButtons.Clear();

    //    }
    //}
}
