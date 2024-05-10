using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieContact : MonoBehaviour
{
    int walkSpeed = 1;
    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * walkSpeed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GetComponent<Animator>().SetBool("zombieattack", true);
            GetComponent<Animator>().SetBool("zombiewalk", false);
        }
    }
}