using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int moveSpeed = 10;
    private int jumpForce = 8;
    private bool isJumping = false;
    private Rigidbody rb;
    private BoxCollider boxCollider;
    public GameObject blockHitbox, attackHitBox;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        boxCollider = GetComponent<BoxCollider>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.D)) // Walk Back
        {
            GetComponent<Animator>().SetBool("RunForward", true);
            GetComponent<Animator>().SetBool("Idle", false);
            moveSpeed = 10;
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.A)) // Walk Forward
        {
            GetComponent<Animator>().SetBool("RunForward", true);
            GetComponent<Animator>().SetBool("Idle", false);
            moveSpeed = 5;
            transform.Translate(Vector3.back * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping) // Jump
        {
            GetComponent<Animator>().SetTrigger("Jump");
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.Mouse0)) // Hitting
        {
            StartCoroutine(ActivateHitBoxAfterDelay());
            GetComponent<Animator>().SetTrigger("Punch");
            StartCoroutine(DeactivateHitBoxAfterDelay());
        }
        if (Input.GetKey(KeyCode.Mouse1)) // Blocking
        {
            GetComponent<Animator>().SetBool("Guard", true);
            GetComponent<Animator>().SetBool("Idle", false);
            blockHitbox.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            GetComponent<Animator>().SetBool("Guard", false);
            GetComponent<Animator>().SetBool("Idle", true);
            blockHitbox.SetActive(false);
        }
        if (Input.GetKey(KeyCode.LeftShift)) // Crouch
        {
            GetComponent<Animator>().SetBool("Crouch", true);
            GetComponent<Animator>().SetBool("Idle", false);
            moveSpeed = 5;
            boxCollider.center = new Vector3(boxCollider.center.x, 0.91f, boxCollider.center.z);
            boxCollider.size = new Vector3(1.5f, -0.5f, 1.22488f);
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            GetComponent<Animator>().SetBool("Crouch", false);
            GetComponent<Animator>().SetBool("Idle", true);
            boxCollider.center = new Vector3(boxCollider.center.x, 1.37f, boxCollider.center.z);
            boxCollider.size = new Vector3(1.5f, 2.81f, 1.22488f);

        }
        if (!Input.anyKey) // Doing Nothing
        {
            GetComponent<Animator>().SetBool("RunForward", false);
            GetComponent<Animator>().SetBool("Idle", true);
        }
    }

    void Jump()
    {
        isJumping = true;
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

    private IEnumerator ActivateHitBoxAfterDelay()
    {
        yield return new WaitForSeconds(1);
        attackHitBox.SetActive(true);
    }

    private IEnumerator DeactivateHitBoxAfterDelay()
    {
        yield return new WaitForSeconds(2);
        attackHitBox.SetActive(false);
    }
}