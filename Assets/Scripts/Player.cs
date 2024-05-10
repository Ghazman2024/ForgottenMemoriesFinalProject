using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int moveSpeed = 10;
    public int jumpForce = 5;
    private bool isJumping = false;
    private Rigidbody rb;
    public GameObject blockHitbox;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
            GetComponent<Animator>().SetTrigger("Punch");
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
}