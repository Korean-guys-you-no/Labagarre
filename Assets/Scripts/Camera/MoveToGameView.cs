using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToGameView : MonoBehaviour
{
    public float startCooldown = 2f;
    public GameObject target;

    private bool moveCamera = false;

    void Start()
    {
        StartCoroutine(StartTimer());
    }

    void Update()
    {
        if (moveCamera)
        {
            GoToGameView();
        }
    }

    private void GoToGameView()
    {
        if (transform.position != target.transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * 7);
        } else
        {
            moveCamera = false;
            GameManager.instance.StartGame();
        }
    }

    IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(startCooldown);
        moveCamera = true;
    }
}
