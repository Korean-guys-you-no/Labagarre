using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    private float knockBackCooldown = 0.5f;
    private float ballKnockBackStrength = 30f;
    private float knockBackStrength = 200f;
    private Rigidbody Rb;
    private PursueTarget pursueTarget;

    private void Awake()
    {
        Rb = GetComponent<Rigidbody>();
        pursueTarget = GetComponent<PursueTarget>();
    }

    private IEnumerator KnockBackCooldown()
    {
        yield return new WaitForSeconds(knockBackCooldown);
        pursueTarget.knockBack = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Player"))
        {
            var dir = (transform.position - other.transform.position).normalized;
            Rb.velocity = dir * ballKnockBackStrength;
            pursueTarget.knockBack = true;
            StartCoroutine(KnockBackCooldown());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand") && other.gameObject.activeInHierarchy)
        {
            var dir = (transform.position - other.transform.position).normalized;
            Rb.velocity = dir * knockBackStrength;
            pursueTarget.knockBack = true;
            StartCoroutine(KnockBackCooldown());
        }
    }
}
