using System.Collections;
using UnityEngine;

public class RandomGroupAnimation : MonoBehaviour
{
    private string[] animations = { "idle", "applause", "applause2", "celebration", "celebration2", "celebration3" };

    void Start()
    {
        foreach (Transform zone in transform) // Iterate over each Zone
        {
            foreach (Transform row in zone) // Iterate over each Row in the Zone
            {
                foreach (Transform group in row) // Iterate over each group1 in the Row
                {
                    foreach (Transform audienceMember in group) // Iterate over each Audience member in the group1
                    {
                        Animation animation = audienceMember.GetComponent<Animation>();
                        if (animation != null) // Check if the Audience member has an Animation component
                        {
                            StartCoroutine(ChangeAnimation(animation));
                        }
                    }
                }
            }
        }
    }

    IEnumerator ChangeAnimation(Animation animation)
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(2, 5)); // Random delay
            string randomAnimation = animations[Random.Range(0, animations.Length)];
            animation.Play(randomAnimation);
        }
    }
}
