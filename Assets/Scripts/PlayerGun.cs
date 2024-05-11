using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    public int amoRemaning = 20;
    public GameObject amoTxt, amoCreats5, amoCreats10, amoCreats15;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) // Shooting
        {
            amoRemaning--;
        }
        amoTxt.GetComponent<TMP_Text>().text = amoRemaning.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (other.gameObject == amoCreats5)
            {
                amoRemaning += 5;
            }
            else if (other.gameObject == amoCreats10)
            {
                amoRemaning += 10;
            }
            else if (other.gameObject == amoCreats15)
            {
                amoRemaning += 15;
            }
        }
    }
}
