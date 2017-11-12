using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Text timer;
    public float maxTime = 2;
    public bool ended = false;

	void Update () {
        if (ended)
        {
            return;
        }

        var minutes = (int)(Time.timeSinceLevelLoad / 60f);
        var seconds = (int)(Time.timeSinceLevelLoad % 60f);
        var currentMinutes = Mathf.Clamp(maxTime - minutes, 0, 3);
        var currentSeconds = Mathf.Clamp(59 - seconds, 0, 59);

        if(currentMinutes == 0 && currentSeconds == 0)
        {
            OnFinish();
        }

        timer.text = currentMinutes.ToString("0") + ":" + currentSeconds.ToString("00");
    }

    public virtual void OnFinish()
    {
        ended = true;
        Debug.Log("End.");
    }
}
