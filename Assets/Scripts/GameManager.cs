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
    public GameObject[] player1Spawners;
    public GameObject[] player2Spawners;
    public GameObject player1Prefab;
    public GameObject player2Prefab;
    public int maxLives = 3;
    public string player1Name = "Player(Clone)";

    private float timeSinceStart;
    private bool gameEnd;
    private int player1Lives;
    private int player2Lives;
    private GameObject player1;
    private GameObject player2;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        GameEnded = false;   
    }

    private void Awake()
    {
        var player1Spawner = player1Spawners[Random.Range(0, 2)];
        var player2Spawner = player2Spawners[Random.Range(0, 2)];

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        player1 = Instantiate(player1Prefab, player1Spawner.transform.position, player1Spawner.transform.rotation);
        player1Lives = maxLives;
        player2 = Instantiate(player2Prefab, player2Spawner.transform.position, player2Spawner.transform.rotation);
        player2Lives = maxLives;

    }

    // Update is called once per frame
    void Update()
    {
        TimeSinceStart += Time.deltaTime;
        if (TimeSinceStart >= GameDuration)
            GameEnded = true;
        if (player1Lives <= 0 || player2Lives <= 0)
        {
            GameEnded = true;
            ReloadScene();
        }
    }

    public void Respawn(GameObject player)
    {
        if (player.name == player1Name)
        {
            Player1Respawn();
            player1Lives--;
        } else
        {
            Player2Respawn();
            player2Lives--;
        }
    }

    private void Player1Respawn()
    {
        var player1Spawner = player1Spawners[Random.Range(0, 2)];

        player1.GetComponent<CharacterController>().enabled = false;
        player1.transform.position = player1Spawner.transform.position;
        player1.transform.rotation = player1Spawner.transform.rotation;
        player1.GetComponent<CharacterController>().enabled = true;
    }

    private void Player2Respawn()
    {
        var player2Spawner = player2Spawners[Random.Range(0, 2)];

        player2.GetComponent<CharacterController>().enabled = false;
        player2.transform.position = player2Spawner.transform.position;
        player2.transform.rotation = player2Spawner.transform.rotation;
        player2.GetComponent<CharacterController>().enabled = true;
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
