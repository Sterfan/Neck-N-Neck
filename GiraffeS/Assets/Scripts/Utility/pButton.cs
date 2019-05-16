using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class pButton : MonoBehaviour
{
    public enum SelectionState
    {
        ByNone,
        FromTop,
        FromBot,
        ByBoth
    }

    private void OnEnable()
    {
        SelectButton.buttons.Add(this);
        //Debug.Log(gameObject.name + " is one of them");
    }

    private void OnDisable()
    {
        SelectButton.buttons.Remove(this);
        //Debug.Log(gameObject.name + " is not one of them anymore");
    }

    SelectionState selected = SelectionState.ByNone;

    public bool twoPlayerSelection;

    [HideInInspector]
    public int _FunctionIndex;
    [HideInInspector]
    public List<string> Functions = new List<string>(new string[6] { "No Function", "Next Scene", "2", "3", "4", "5" });

    private void Function()
    {
        pButtonFunctions.GetFunction(_FunctionIndex);
    }

    public void Selected(int grff)
    {
        switch(grff)
        {
            case 1:
                Debug.Log("Selected " + selected);
                if (selected == SelectionState.FromBot)
                    selected = SelectionState.ByBoth;
                else
                    selected = SelectionState.FromTop;
                //selected = SelectionState.ByBoth;
                break;
            case 2:
                Debug.Log("Selected " + selected);
                if (selected == SelectionState.FromTop)
                    selected = SelectionState.ByBoth;
                else
                    selected = SelectionState.FromBot;
                //selected = SelectionState.ByBoth;
                break;
        }
        if (twoPlayerSelection)
        {
            if (selected.Equals(SelectionState.ByBoth))
                Function();
        }
        else if (selected.Equals(SelectionState.FromTop) || selected.Equals(SelectionState.FromBot))
            Function();
    }

    public void Deselected(int grff)
    {
        switch (grff)
        {
            case 1:
                Debug.Log("Deselected " + selected);
                if (selected == SelectionState.FromTop)
                    selected = SelectionState.ByNone;
                else
                    selected = SelectionState.FromBot;
                //GetComponentInChildren<SelectButton>().DeactivateLeaf();
                transform.GetChild(0).gameObject.SetActive(false);
                break;
            case 2:
                Debug.Log("Deselected " + selected);
                if (selected == SelectionState.FromBot)
                    selected = SelectionState.ByNone;
                else
                    selected = SelectionState.FromTop;
                //Debug.Log(GetComponentInChildren<SelectButton>().gameObject.name);
                transform.GetChild(1).gameObject.SetActive(false);
                break;
        }
    }
}
