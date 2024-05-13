using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    public int ammoRemaining = 20;
    public GameObject ammoTxt, pressEtxt, noAmmoTxt, bullet;
    private const int AMMO_INCREMENT_5 = 5;
    private const int AMMO_INCREMENT_10 = 10;
    private const int AMMO_INCREMENT_15 = 15;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) // Shooting
        {
            ammoRemaining = Math.Max(0, ammoRemaining - 1);
            UpdateAmmoText();
            bullet.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (IsAmmoPickup(other))
        {
            pressEtxt.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E) && IsAmmoPickup(other))
        {
            PickUpAmmo(other);
        }
    }

    private void PickUpAmmo(Collider other)
    {
        int ammoAmount = GetAmmoAmountFromTag(other.tag);
        ammoRemaining += ammoAmount;
        Destroy(other.gameObject);
        pressEtxt.SetActive(false);
        UpdateAmmoText();
    }

    private void OnTriggerExit(Collider other)
    {
        pressEtxt.SetActive(false);
    }

    private bool IsAmmoPickup(Collider other)
    {
        return other.tag == "5Ammo" || other.tag == "10Ammo" || other.tag == "15Ammo";
    }

    private int GetAmmoAmountFromTag(string tag)
    {
        switch (tag)
        {
            case "5Ammo":
                return AMMO_INCREMENT_5;
            case "10Ammo":
                return AMMO_INCREMENT_10;
            case "15Ammo":
                return AMMO_INCREMENT_15;
            default:
                return 0;
        }
    }

    private void UpdateAmmoText()
    {
        ammoTxt.GetComponent<TMP_Text>().text = ammoRemaining.ToString();
        if (ammoRemaining <= 0)
        {
            noAmmoTxt.SetActive(true);
            StartCoroutine(NoAmoWarning());
        }
    }
    private IEnumerator NoAmoWarning()
    {
        yield return new WaitForSeconds(3);
        noAmmoTxt.SetActive(false);
    }
}