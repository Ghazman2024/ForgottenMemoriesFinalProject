using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ZombieHealth : MonoBehaviour
{
    public int healthNumber = 10;
    public GameObject healthText;
    public float knockbackForce = 5f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        healthNumber = 10;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerAttack")
        {
            healthNumber -= 1;
            rb.AddForce(other.transform.right * knockbackForce, ForceMode.Impulse);
        }
        else if (other.tag == "Bullet")
        {
            healthNumber -= 2;
        }
        if (healthNumber == 0)
        {
            Invoke("DestroyEnemy", 0.1f);
            // GetComponent<Animator>().SetBool("Die", true);
        }
        healthText.GetComponent<TMP_Text>().text = healthNumber.ToString();
    }

    private void DestroyEnemy()
    {
        Destroy(this.gameObject);
    }
}