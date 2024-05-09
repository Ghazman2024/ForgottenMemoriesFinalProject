using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int healthNumber = 10;
    public GameObject healthText, gameOverScreen;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            healthNumber -= 1;
        }
        if (healthNumber == 0)
        {
            GetComponent<Animator>().SetBool("Die", true);
        }
        healthText.GetComponent<TMP_Text>().text = healthNumber.ToString();
    }
}
