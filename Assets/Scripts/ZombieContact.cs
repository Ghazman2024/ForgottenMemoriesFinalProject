using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieContact : MonoBehaviour
{
    int walkSpeed = 1;
    public GameObject attackHitBox;
    private Animator animator;
    private Rigidbody rb;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezePositionZ;
        rb.freezeRotation = true;
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * walkSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            walkSpeed = 0;
            StartCoroutine(ActivateHitBoxAfterDelay());
            animator.SetBool("zombieattack", true);
            animator.SetBool("zombiewalk", false);
            StartCoroutine(DeactivateHitBoxAfterDelay());
        }
    }

    private IEnumerator ActivateHitBoxAfterDelay()
    {
        yield return new WaitForSeconds(1);
        attackHitBox.SetActive(true);
    }

    private IEnumerator DeactivateHitBoxAfterDelay()
    {
        yield return new WaitForSeconds(3);
        walkSpeed = 1;
        attackHitBox.SetActive(false);
    }
}