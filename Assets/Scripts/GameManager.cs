using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float TimeSinceStart { private set { timeSinceStart = value; } get { return timeSinceStart; }}
    public bool GameEnded { private set { gameEnd = value; } get { return gameEnd; } }

    public float GameDuration;
    private float timeSinceStart;
    private bool gameEnd;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        GameEnded = false;
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
        if (TimeSinceStart >= GameDuration)
            GameEnded = true;
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
