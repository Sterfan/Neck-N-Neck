using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temp : MonoBehaviour
{
    [SerializeField] private float newScore;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<ScoreBoard>().NewScore(newScore);   
    }
}
