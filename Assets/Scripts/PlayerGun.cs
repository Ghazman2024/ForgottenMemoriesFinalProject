using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    public int amoRemaning = 50;
    public GameObject amoTxt, amoCreats10, amoCreats15, amoCreats20;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) // Blocking
        {
            amoRemaning--;
        }
        amoTxt.GetComponent<TMP_Text>().text = amoRemaning.ToString();
    }
}
