using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int healthNumber = 10;
    public GameObject healthText, gameOverScreen;
    private bool isPaused = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyAttackBox")
        {
            healthNumber -= 1;
        }
        if (healthNumber == 0)
        {
            GetComponent<Animator>().SetBool("Die", true);
            StartCoroutine(WaitForAnimation());

        }
        healthText.GetComponent<TMP_Text>().text = healthNumber.ToString();
    }
    private IEnumerator WaitForAnimation()
    {
        yield return new WaitForSeconds(4);
        gameOverScreen.SetActive(true);
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0 : 1;
    }
}
