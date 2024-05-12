using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockZPotion : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        rb.constraints = RigidbodyConstraints.FreezePositionZ;
    }
}