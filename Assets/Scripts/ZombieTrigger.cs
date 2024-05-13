using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieTrigger : MonoBehaviour
{
    public GameObject spawnEnemy;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            spawnEnemy.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}