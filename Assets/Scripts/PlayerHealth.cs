using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int healthNumber = 10;
    public GameObject healthText, gameOverScreen;

    private void OnTriggerEnter(Collider other)
    {
        if (healthNumber == 0)
        {
            GetComponent<Animator>().SetBool("Die", true);
        }
    }
}
