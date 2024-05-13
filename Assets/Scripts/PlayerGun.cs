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
    private float cooldown = 0.5f; //  0.5 seconds cooldown

    void Update()
    {
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
        else if (Input.GetKeyDown(KeyCode.F) && ammoRemaining > 0) // Shooting
        {
            ammoRemaining--;
            UpdateAmmoText();

            // Create a new bullet instance
            GameObject newBullet = Instantiate(bullet, bullet.transform.position, bullet.transform.rotation);
            newBullet.SetActive(true); // Set the new bullet to be active

            cooldown = 0.5f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (IsAmmoPickup(other))
        {
            pressEtxt.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other) // Picking Up Ammo
    {
        if (Input.GetKeyDown(KeyCode.E) && IsAmmoPickup(other))
        {
            PickUpAmmo(other);
        }
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

    private void PickUpAmmo(Collider other)
    {
        int ammoAmount = GetAmmoAmountFromTag(other.tag);
        ammoRemaining += ammoAmount;
        Destroy(other.gameObject);
        pressEtxt.SetActive(false);
        UpdateAmmoText();
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