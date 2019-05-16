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

    SelectionState selected = SelectionState.ByNone;

    public bool twoPlayerSelection;

    [HideInInspector]
    public int _FunctionIndex;
    [HideInInspector]
    public List<string> Functions = new List<string>(new string[] { "No Function", "Next Scene" });

    private void Update()
    {
        if (twoPlayerSelection)
        {
            if (selected.Equals(SelectionState.ByBoth))
                Function();
        }
        else if (selected.Equals(SelectionState.FromTop) || selected.Equals(SelectionState.FromBot)) { }
            Function();
    }

    private void Function()
    {
        pButtonFunctions.GetFunction(_FunctionIndex);
    }

    public void Selected(int grff)
    {
        switch(grff)
        {
            case 1:
                if (selected == SelectionState.FromBot)
                    selected = SelectionState.ByBoth;
                else
                    selected = SelectionState.FromTop;
                break;
            case 2:
                if (selected == SelectionState.FromTop)
                    selected = SelectionState.ByBoth;
                else
                    selected = SelectionState.FromBot;
                break;
            default:
                Debug.LogError("something went wrong with selecting the button.");
                break;
        }
    }
}
