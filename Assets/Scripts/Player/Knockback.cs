using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    private Animator animator;

    float mass = 3.0F; // defines the character mass
    Vector3 impact = Vector3.zero;
    private CharacterController character;

    // Use this for initialization
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        character = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // apply the impact force:
        if (impact.magnitude > 0.2F) character.Move(impact * Time.deltaTime);
        // consumes the impact energy each cycle:
        impact = Vector3.Lerp(impact, Vector3.zero, 5 * Time.deltaTime);
    }
    // call this function to add an impact force:
    public void AddKnockback(Vector3 dir, float force)
    {
        dir.Normalize();
        if (dir.y < 0) dir.y = -dir.y; // reflect down force on the ground
        impact += dir.normalized * force / mass;
    }

    private IEnumerator damageAnim()
    {
        animator.SetBool("Damage", true);
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("Damage", false);
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            AddKnockback(other.transform.forward, 100);
            StartCoroutine(damageAnim());
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand") && other.gameObject.activeInHierarchy) //  && other.GetInstanceID() != GetComponent<Punch>().hand.GetInstanceID() //  && other != GetComponent<Punch>().hand
        {
            AddKnockback(other.transform.forward, 30);
            StartCoroutine(damageAnim());
        }
    }
}
