using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDeath : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Lava"))
        {
            GameManager.instance.ReloadScene();
        }
    }

    //private void OnCollisionEnter(Collision other)
    //{
    //    Debug.Log("ici");
    //    if (other.gameObject.CompareTag("Lava"))
    //    {
    //        Debug.Log("là");
    //        gameManager.ReloadScene();
    //    }
    //}
}
