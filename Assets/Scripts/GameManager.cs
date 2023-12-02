using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private float timeSinceStart;
    public float TimeSinceStart { private set { timeSinceStart = value; } get { return timeSinceStart; }}
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        TimeSinceStart += Time.deltaTime;
    }

}
