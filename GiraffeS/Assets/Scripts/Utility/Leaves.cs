using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaves : MonoBehaviour
{
    Component[] leaves;

    private void Start()
    {
        leaves = GetComponentsInChildren<Leaf>();
    }

    public void StartShakyShaky()
    {
        foreach (Leaf leaf in leaves)
            leaf.GetInThere();
    }
}
