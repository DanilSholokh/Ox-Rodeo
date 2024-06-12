using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerDisplay : MonoBehaviour
{
    private float startTime = -3f;
    public float currentTime;
    public TextMeshProUGUI timerText; 

    void Start()
    {
        currentTime = startTime;
    }


    public void strtTimer()
    {
        currentTime += Time.deltaTime; 

        UpdateTimerText(currentTime);
    }

    public void zeroTime()
    {
        currentTime = startTime;
        UpdateTimerText(currentTime);
    }

    void UpdateTimerText(float time)
    {
        int totalSeconds = Mathf.FloorToInt(time);
        int minutes = Mathf.FloorToInt(Mathf.Abs(totalSeconds / 60f));
        int seconds = Mathf.Abs(totalSeconds % 60);

        string timeText;
        if (totalSeconds < 0)
        {
            timeText = string.Format("-{0:00}:{1:00}", minutes, seconds);
        }
        else
        {
            timeText = string.Format("{0:00}:{1:00}", minutes, seconds);
        }

        timerText.text = timeText;
    }
}
