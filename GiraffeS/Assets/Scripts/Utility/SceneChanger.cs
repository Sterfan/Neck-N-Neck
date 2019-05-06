using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKey(KeyCode.Y))
        {
            SceneManager.LoadScene("BackupScene");
        }
    }
}
