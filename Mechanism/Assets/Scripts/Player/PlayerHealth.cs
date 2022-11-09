/*
 * Project Mechanism
 * Last Updated: 10/31/2022
 * 
 * Description: Implementation for managing the health of the player. 
 *      As a side note, this code COULD work for AI. More testing to be determined.
 * 
 * Christ is King.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Image healthBar; //TODO: change this to adjust to UI implementation
    public float healthAmount = 100;

    private void Update()
    {
        //Player Death
        if(healthAmount <= 0)
        {


            //TODO: Kill the player
        }


        //TODO: Take Damage triggers?
    }

    public void TakeDamage(float Damage)
    {
        healthAmount -= Damage;

        //Update Healthbar
        healthBar.fillAmount = healthAmount / 100; //TODO: change this to accomodate GUI implementation
    }

    public void RestoreHealth(float HealthPoints)
    {
        healthAmount += HealthPoints;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100); //Prevent HealthBar from going outside bounds of 0 and 100

        //Update Healthbar
        healthBar.fillAmount = healthAmount / 100; //TODO: change this to accomodate GUI implementation
    }
}
