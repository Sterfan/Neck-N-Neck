using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaSpawner : MonoBehaviour
{
    public GameObject countdownTimer;
    public GameObject Banana;
    public Transform[] SpawnPoints;

    bool hasStarted = false;

    void Update()
    {
        if (countdownTimer.GetComponent<CountdownTimer>().startGame == true && hasStarted == false)
        {

            StartCoroutine(StartSpawning());
            hasStarted = true;
        }
    }

    IEnumerator StartSpawning()
    {
        yield return new WaitForSeconds(Random.Range(1f, 3.5f));
        Instantiate(Banana, SpawnPoints[Random.Range(0, SpawnPoints.Length)].position, Quaternion.identity);
        StartCoroutine(StartSpawning());
    }

}
