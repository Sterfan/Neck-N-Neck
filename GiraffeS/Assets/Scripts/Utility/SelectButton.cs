using UnityEngine;
using System.Collections.Generic;

public class SelectButton : MonoBehaviour/*, ISelectHandler, IDeselectHandler*/
{
    [SerializeField]
    GameObject giraffeHead;

    [SerializeField]
    pButton button;

    [SerializeField]
    Sprite buttonNormal;
    [SerializeField]
    Sprite buttonHovered;

    [SerializeField]
    GameObject leaf;

    public static List<pButton> buttons = new List<pButton>();

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == giraffeHead)
        {
            if (button.GetComponent<SpriteRenderer>().sprite != buttonHovered)
                button.GetComponent<SpriteRenderer>().sprite = buttonHovered;

            //if (Input.GetKey(KeyCode.W) && collision.GetComponent<HeadMovement2>().xGiraffe)
            //{
            //    //Debug.Log("W was pressed when graffe was in the collider");
            //    InvokeSelection(1);
            //}
            //if (Input.GetKey(KeyCode.Space) && collision.GetComponent<HeadMovement2>().yGiraffe)
            //{
            //    //Debug.Log("Space was pressed when graffe was in the collider");
            //    InvokeSelection(2);
            //}
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        button.GetComponent<SpriteRenderer>().sprite = buttonNormal;
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
