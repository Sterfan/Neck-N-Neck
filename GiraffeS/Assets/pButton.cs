using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class pButton : MonoBehaviour, IDeselectHandler
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
        else if (selected.Equals(SelectionState.FromTop) || selected.Equals(SelectionState.FromBot))
            Function();
    }

    private void Function()
    {
        pButtonFunctions.GetFunction(_FunctionIndex);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
