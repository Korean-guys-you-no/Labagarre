using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TextTimer : MonoBehaviour
{
    private Timer timer;
    private GameManager manager;
    private TextMeshProUGUI textTimer;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameManager.instance;
        textTimer = GetComponentInChildren<TextMeshProUGUI>();
        timer = gameObject.AddComponent<Timer>();
        timer.SetTime(1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.CountdownEnded())
        {
            timer.RestartCountdown();
            UpdateTextTimer();
        }
    }

    void UpdateTextTimer()
    {
        float time = manager.TimeSinceStart;
        int minutes = (int)time / 60;
        int seconds = (int)time % 60;
        textTimer.SetText((minutes < 10 ? "0" : "") + minutes + ":" + (seconds < 10 ? "0" : "") + seconds);
    }
}
