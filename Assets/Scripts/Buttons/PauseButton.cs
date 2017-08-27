using UnityEngine;

public class PauseButton : MonoBehaviour
{
    public GameObject ResumeButton;

    public void Click()
    {
        Time.timeScale = 0;
        ResumeButton.SetActive(true);
    }
}