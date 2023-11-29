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
}
