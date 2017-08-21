using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public void Click()
    {
        SceneManager.LoadScene("Playable1", LoadSceneMode.Single);
        SceneManager.LoadScene("UI", LoadSceneMode.Additive);
    }
}