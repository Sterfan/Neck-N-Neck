using UnityEngine;
using UnityEngine.SceneManagement;

public class exitLeaderboard : MonoBehaviour
{
    bool started;

    public bool HasStarted { set { started = value; } }
    void Update()
    {
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.Space) && !started)
            GetComponent<FadeOut>().StartCoroutine("fadeOut");
    }
}
