using UnityEngine;
using UnityEngine.SceneManagement;

public class exitLeaderboard : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.Space))
            SceneManager.LoadScene("Menu");
    }
}
