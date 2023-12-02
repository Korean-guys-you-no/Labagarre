using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeFillerBar : MonoBehaviour
{
    private GameManager manager;
    private Timer timer;
    private Image image;


    private bool empty = false;
    public bool Empty { private set { empty = value; } get { return empty; } }

    // Start is called before the first frame update
    void Start()
    {
        manager = GameManager.instance;
        image = this.GetComponent<Image>();
        timer = gameObject.AddComponent<Timer>();
        timer.SetTime(1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.CountdownEnded())
        {
            timer.RestartCountdown();
            UpdateFillBar();
        }
    }

    void UpdateFillBar()
    {
        float valueLeft = manager.GameDuration - manager.TimeSinceStart;
        if (valueLeft < 0.0f)
        {
            Empty = true;
        }
        else
            image.fillAmount = valueLeft / manager.GameDuration;

    }

    public void ResetFillBar()
    {
        image.fillAmount = 1;
    }
}
