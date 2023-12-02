using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float _time;
    private float _countdown = 0.0f;

    // Update is called once per frame
    void Update()
    {
        _countdown += Time.deltaTime;
    }

    public bool CountdownEnded()
    {
        return _countdown >= _time;
    }

    public void SetTime(float time)
    {
        _time = time;
    }

    public void RestartCountdown()
    {
        _countdown = 0.0f;
    }
}
