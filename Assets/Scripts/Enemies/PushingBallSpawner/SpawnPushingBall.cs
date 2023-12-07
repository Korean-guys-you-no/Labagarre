using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPushingBall : MonoBehaviour
{
    public float spawnDelay = 10f;
    public GameObject pushingBallPrefab;
    public GameObject[] pushingBallSpawners;

    private GameObject spawner;

    void Start()
    {
        spawner = pushingBallSpawners[Random.Range(0, 4)];

        Instantiate(pushingBallPrefab, spawner.transform.position, spawner.transform.rotation);
        StartCoroutine(SpawnBall());
    }

    private IEnumerator SpawnBall()
    {
        yield return new WaitForSeconds(spawnDelay);
        spawner = pushingBallSpawners[Random.Range(0, 4)];
        Instantiate(pushingBallPrefab, spawner.transform.position, spawner.transform.rotation);
        StartCoroutine(SpawnBall());
    }
}
