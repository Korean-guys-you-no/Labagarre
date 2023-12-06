using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Punch : MonoBehaviour
{
    [SerializeField]
    private InputActionReference hitInput;

    private Animator animator;

    public GameObject hand;

    public AudioSource punchSoundEffect;

    private bool isPunching = false;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void OnEnable()
    {
        hitInput.action.Enable();
    }

    private void OnDisable()
    {
        hitInput.action.Disable();
    }

    private void Update()
    {
        if (hitInput.action.triggered)
        {
            StartCoroutine(punchAnim());
            if (!isPunching) {
                StartCoroutine(playPunchSoundEffect());
            }
        }
    }

    private IEnumerator punchAnim()
    {
        animator.SetBool("Punch", true);
        hand.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        hand.SetActive(false);
        animator.SetBool("Punch", false);
    }

    private IEnumerator playPunchSoundEffect() 
    {
        isPunching = true;
        punchSoundEffect.Play();
        yield return new WaitForSeconds(punchSoundEffect.clip.length);
        isPunching = false;
    }
}
