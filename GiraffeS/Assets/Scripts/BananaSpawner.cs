using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaSpawner : MonoBehaviour
{
    public GameObject Banana;
    public Transform[] SpawnPoints;
    void Start()
    {
        StartCoroutine(StartSpawning());
    }

    IEnumerator StartSpawning()
    {
        yield return new WaitForSeconds(Random.Range(1f, 3.5f));
        Instantiate(Banana, SpawnPoints[Random.Range(0, SpawnPoints.Length)].position, Quaternion.identity);
        StartCoroutine(StartSpawning());
    }
}
