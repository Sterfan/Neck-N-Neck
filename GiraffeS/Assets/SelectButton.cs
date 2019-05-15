using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System;

public class SelectButton : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    EventSystem m_EventSystem;
    public GameObject giraffeHead;
    //public Button button;
    public GameObject giraffe;

    public static HashSet<pButton> allButtons = new HashSet<pButton>();
    public static HashSet<pButton> currentButtons = new HashSet<pButton>();

    //public Sprite leaf;

    public GameObject counterpart;
    [HideInInspector]
    public bool counterpartSelected = false;

    private void Awake()
    {
        //m_EventSystem = EventSystem.current;
        allButtons.Add(this.GetComponentInParent<pButton>());
        Debug.Log(this.name + " is one of them");
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.name == giraffeHead.name)
    //    {
    //        button.Select();
    //        //m_EventSystem.SetSelectedGameObject(button.gameObject);
    //        counterpart.GetComponent<SelectButton>().counterpartSelected = true;
    //    }
    //}

    ////private void OnTriggerStay2D(Collider2D collision)
    ////{
    ////    if (collision.gameObject.name == giraffeHead.name)
    ////    {
    ////        m_EventSystem.SetSelectedGameObject(button.gameObject);
    ////    }
    ////}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (!counterpartSelected)
    //    {
    //        //m_EventSystem.SetSelectedGameObject(null);
    //        //this.m_EventSystem.SetSelectedGameObject(null);
    //    }
    //    counterpart.GetComponent<SelectButton>().counterpartSelected = false;
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

    public void OnSelect(BaseEventData eventData)
    {
        DeselectAll(eventData);
        currentButtons.Add(this.GetComponentInParent<pButton>());
        //here I leave the leaf (like sprite change if it were one button)
        Debug.Log("ok?");
        transform.parent.transform.Find("Right Leaf").gameObject.SetActive(true);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        //here I take off the leaf
        Debug.Log("ok!");
        transform.parent.transform.Find("Right Leaf").gameObject.SetActive(false);
    }

    public static void DeselectAll(BaseEventData eventData)
    {
        foreach(pButton selectable in currentButtons)
        {
            selectable.OnDeselect(eventData);
            currentButtons.Clear();

        }
    }
}
