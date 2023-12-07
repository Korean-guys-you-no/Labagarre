using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDeath : MonoBehaviour
{
    public AudioSource[] crowdPlayerDeathSounds;

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Lava"))
        {
            //crowdPlayerDeathSounds[Random.Range(0, crowdPlayerDeathSounds.Length)]
            GameManager.instance.Respawn(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Lava"))
        {
            //crowdPlayerDeathSounds[Random.Range(0, crowdPlayerDeathSounds.Length)]
            crowdPlayerDeathSounds[Random.Range(0, crowdPlayerDeathSounds.Length)].Play();
        }
    }
}
