using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDeath : MonoBehaviour
{
    public AudioSource[] crowdPlayerDeathSounds;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Lava"))
        {
            //crowdPlayerDeathSounds[Random.Range(0, crowdPlayerDeathSounds.Length)]
            crowdPlayerDeathSounds[Random.Range(0, crowdPlayerDeathSounds.Length)].Play();
            //GameManager.instance.ReloadScene();

        }
    }

    //private void OnCollisionEnter(Collision other)
    //{
    //    Debug.Log("ici");
    //    if (other.gameObject.CompareTag("Lava"))
    //    {
    //        Debug.Log("l�");
    //        gameManager.ReloadScene();
    //    }
    //}
}
