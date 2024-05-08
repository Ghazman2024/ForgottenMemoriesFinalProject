using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    int moveSpeed = 5;
    int jumpForce = 5;
    GameObject playerDied;
    public void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Animator>().SetBool("Run", true);
            GetComponent<Animator>().SetBool("Idle", false);
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);

        }
        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Animator>().SetBool("Run", true);
            GetComponent<Animator>().SetBool("Idle", false);
            transform.Translate(Vector3.back * Time.deltaTime * moveSpeed);

        }
        if (Input.GetKey(KeyCode.Space))
        {
            GetComponent<Animator>().SetTrigger("Jump");
            GetComponent<Rigidbody>().AddForce(Vector2.up * jumpForce);
        }
        if (!Input.anyKey)
        {
            GetComponent<Animator>().SetBool("Run", false);
            GetComponent<Animator>().SetBool("Idle", true);
        }

    }
}

