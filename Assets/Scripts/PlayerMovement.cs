using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    int moveSpeed = 10;
    int jumpForce = 5;
    public void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Animator>().SetBool("RunForward", true);
            GetComponent<Animator>().SetBool("Idle", false);
            moveSpeed = 10;
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);

        }
        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Animator>().SetBool("RunForward", true);
            GetComponent<Animator>().SetBool("Idle", false);
            moveSpeed = 5;
            transform.Translate(Vector3.back * Time.deltaTime * moveSpeed);

        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Animator>().SetTrigger("Jump");
            transform.Translate(Vector2.up * jumpForce);
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GetComponent<Animator>().SetTrigger("Punch");
        }
        if (Input.GetKey(KeyCode.Mouse1))
        {
            GetComponent<Animator>().SetBool("Guard", true);
            GetComponent<Animator>().SetBool("Idle", false);
        }
        if (!Input.anyKey)
        {
            GetComponent<Animator>().SetBool("RunForward", false);
            GetComponent<Animator>().SetBool("Idle", true);
        }
    }
}