using UnityEngine;

public class ResumeButton : MonoBehaviour
{
    public void Click()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
